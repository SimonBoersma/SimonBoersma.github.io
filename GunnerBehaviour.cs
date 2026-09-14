using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class GunnerBehaviour : MonoBehaviour
{
    [SerializeField] Transform[] checkpoints;
    private int currentCheckpointIndex = 0;
    private bool isMovingToCheckpoint = true;
    public bool gunnerPatrolling = false;

    [SerializeField] Transform target;

    NavMeshAgent agent;

    GlobalVariables variables;


    public bool gunnerHasSight = false;
    [SerializeField] private float sightRange = 10f;
    [SerializeField] private float fieldOfViewAngle = 90f;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private LayerMask lowerObstacleLayer;


    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawnPosition;
    [SerializeField] private GameObject ejectPrefab;
    [SerializeField] private GameObject ejectSpawnPosition;
    [SerializeField] private float bulletSpeed = 30f;
    [SerializeField] private float shootingCooldown = 1f;
    private float lastShotTime = 0f;
    [SerializeField] int gunnerAmmo = 30;
    [SerializeField] int gunnerMaxAmmo = 30;
    [SerializeField] private float reloadTime = 2f;
    private bool isReloading = false;
    [SerializeField] float reactionTime = 0.2f;
    private float reactionTimer;
    [SerializeField] float standStillTime = 0.5f;
    private float standStillTimer;

    private float timer;

    MoveCamera camera;
    AnimationHandler animationHandler;

    [SerializeField] GameObject question;
    [SerializeField] GameObject actionQuestion;
    [SerializeField] GameObject action;

    public GameObject activeBehavior;

    private bool isInCamera;
    private float inSightTimer;

    private Vector3 normalScale = Vector3.one;
    private Vector3 smallScale = Vector3.one * 0.01f;
    private float upScaleSpeed = 5f;
    private float downScaleSpeed = 2f;

    //[SerializeField] private float rotationSpeed = 2f;
    //[SerializeField] private float maxRotationAngle = 45f;

    public AudioGroupManager audioGroupManager;
    private AudioSource audioSource;

    [SerializeField] AudioClip gunShot;
    [SerializeField] AudioClip reload;

    PlayerAbility playerAbility;

    private bool isHitByIce = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        variables = FindFirstObjectByType<GlobalVariables>();
        animationHandler = GetComponent<AnimationHandler>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        activeBehavior = Instantiate(question, transform.position + Vector3.up * 1f, Quaternion.identity);
        activeBehavior.transform.SetParent(transform);

        camera = FindFirstObjectByType<MoveCamera>();

        GameObject[] checkpointObjects = GameObject.FindGameObjectsWithTag("Checkpoint");

        checkpoints = checkpointObjects.Select(obj => obj.transform).ToArray();

        ChooseRandomCheckpoint();

        audioGroupManager = FindFirstObjectByType<AudioGroupManager>();
        audioSource = GetComponent<AudioSource>();
        if (audioGroupManager != null)
        {
            audioSource.outputAudioMixerGroup = audioGroupManager.GetNextAvailableGroup();
        }
        else
        {
            Debug.LogWarning("AudioGroupManager not set on enemy!");
        }

        playerAbility = FindFirstObjectByType<PlayerAbility>();
    }
    private void Update()
    {
        RotateTowardsTarget();

        CheckIfInCameraView();
        if (isInCamera)
        {
            inSightTimer += Time.deltaTime;
            if (inSightTimer > 1f)
            {
                activeBehavior.transform.localScale = Vector3.Lerp(activeBehavior.transform.localScale, smallScale, Time.deltaTime * downScaleSpeed);
            }
            else
            {
                activeBehavior.transform.localScale = Vector3.Lerp(activeBehavior.transform.localScale, normalScale, Time.deltaTime * upScaleSpeed);
            }
        }
        else
        {
            inSightTimer = 0f;
            activeBehavior.transform.localScale = Vector3.Lerp(activeBehavior.transform.localScale, smallScale, Time.deltaTime * downScaleSpeed);
        }

        GameObject newBehaviour;

        if (!variables.isEnemyAlerted && !variables.isPlayerDetected)
        {
            newBehaviour = question;
            timer = 0f;
            Patrol(2f);
            DetectPlayer();
        }
        else if (variables.isEnemyAlerted && !variables.isPlayerDetected)
        {
            newBehaviour = actionQuestion;
            timer = 0f;
            if (isHitByIce)
            {
                Patrol(1f);
            }
            else
            {
                Patrol(3f);
            }
            DetectPlayer();
        }
        else
        {
            newBehaviour = action;
            timer += Time.deltaTime;
            target = variables.player;
            if (timer > 0.5f)
            {
                LineOfSight();

                gunnerPatrolling = false;

                if (isHitByIce)
                {
                    agent.speed = 1f;
                }
                else
                {
                    agent.speed = 3f;
                }

                if (gunnerHasSight)
                {
                    //agent.isStopped = true;
                    standStillTimer += Time.deltaTime;
                    if (standStillTimer > standStillTime)
                    {
                        agent.velocity = Vector3.zero;
                        animationHandler.SetWalking(false);
                    }

                    if (gunnerAmmo > 0)
                    {
                        reactionTimer += Time.deltaTime;
                        if (reactionTimer > reactionTime)
                        {
                            if (Time.time >= lastShotTime + shootingCooldown)
                            {
                                Shoot();
                                Eject();
                                camera.StartShake(0.32f, 0.6f);
                                lastShotTime = Time.time;
                            }
                        }
                    }
                    else
                    {
                        if (!isReloading)
                        {
                            audioSource.PlayOneShot(reload);
                            StartCoroutine(Reload());
                        }
                        else
                        {
                            agent.speed = 1f;
                        }
                    }
                }
                else
                {
                    reactionTimer = 0f;
                    standStillTimer = 0f;
                    agent.isStopped = false;
                    ChasePlayer();
                }
            }
        }
        if (activeBehavior == null || activeBehavior.name != newBehaviour.name + "(Clone)")
        {
            if (activeBehavior != null)
            {
                Destroy(activeBehavior);
            }

            activeBehavior = Instantiate(newBehaviour, transform.position + Vector3.up * 1f, Quaternion.identity);
            activeBehavior.transform.SetParent(transform);
            inSightTimer = 0f;
        }
        if (activeBehavior != null)
        {
            activeBehavior.transform.position = transform.position + Vector3.up * 1f;
            activeBehavior.transform.rotation = Quaternion.identity;
        }
    }

    void CheckIfInCameraView()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);

        isInCamera = screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }

    void Patrol(float agentSpeed)
    {
        if (checkpoints.Length == 0 || !isMovingToCheckpoint) return;

        gunnerPatrolling = true;
        agent.speed = agentSpeed;
        Transform newTarget = checkpoints[currentCheckpointIndex];
        target = newTarget;
        agent.SetDestination(target.position);
    }

    public void ChooseRandomCheckpoint()
    {
        isMovingToCheckpoint = false;
        animationHandler.SetWalking(false);

        int newCheckpointIndex;
        do
        {
            newCheckpointIndex = Random.Range(0, checkpoints.Length);
        } while (newCheckpointIndex == currentCheckpointIndex);

        currentCheckpointIndex = newCheckpointIndex;
        isMovingToCheckpoint = true;
        animationHandler.SetWalking(true);
    }

    void ChasePlayer()
    {
        target = variables.player;
        agent.SetDestination(target.position);
        animationHandler.SetWalking(true);
        StartCoroutine(ResetShootingAnimation());
    }

    void RotateTowardsTarget()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //if (agent.isStopped)
        //{
        //    float offset = Mathf.Sin(Time.time * rotationSpeed) * maxRotationAngle;
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90 + offset));
        //}
        //else
        //{
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        //}
    }

    public Transform GetCurrentTarget()
    {
        return target;
    }

    void DetectPlayer()
    {
        Vector2 directionToPlayer = variables.player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        Color sightLineColor = Color.green;

        if (distanceToPlayer <= sightRange)
        {
            float angleToPlayer = Vector2.Angle(transform.up, directionToPlayer);

            if (angleToPlayer <= fieldOfViewAngle / 2)
            {

                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, sightRange, obstacleLayer);

                if (hit.collider == null || hit.collider.CompareTag("Player"))
                {
                    if (playerAbility.isCloakActive || playerAbility.isHackActive) return;
                    variables.isEnemyAlerted = true;
                    variables.isPlayerDetected = true;
                    gunnerHasSight = true;
                    target = variables.player;
                    sightLineColor = Color.green;
                }
                else
                {
                    gunnerHasSight = false;
                    sightLineColor = Color.red;
                }
            }
            else
            {
                gunnerHasSight = false;
                sightLineColor = Color.red;
            }
        }
        else
        {
            gunnerHasSight = false;
            sightLineColor = Color.red;
        }

        Debug.DrawRay(transform.position, directionToPlayer, sightLineColor);
        Debug.DrawRay(transform.position, Quaternion.Euler(0, 0, fieldOfViewAngle / 2) * transform.up * sightRange, Color.red);
        Debug.DrawRay(transform.position, Quaternion.Euler(0, 0, -fieldOfViewAngle / 2) * transform.up * sightRange, Color.red);
    }

    void LineOfSight()
    {
        if (variables.player == null) return;


        LayerMask sightLayerMask = LayerMask.GetMask("Player", "Objects");

        RaycastHit2D ray = Physics2D.Raycast(transform.position, variables.player.position - transform.position, Mathf.Infinity, sightLayerMask);

        if (ray.collider != null)
        {
            gunnerHasSight = ray.collider.CompareTag("Player");

            if (gunnerHasSight)
            {
                variables.isPlayerDetected = true;
                Debug.DrawRay(transform.position, variables.player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, variables.player.transform.position - transform.position, Color.red);
            }
        }
    }

    private void Shoot()
    {
        Vector2 bulletDirection = (variables.player.position - bulletSpawnPosition.transform.position).normalized;
        float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;

        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPosition.transform.position, Quaternion.Euler(0, 0, angle - 90));

        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            audioSource.PlayOneShot(gunShot);
            rb.linearVelocity = bulletDirection * bulletSpeed;
            animationHandler.SetShooting(true);
            gunnerAmmo--;
        }
    }

    private IEnumerator ResetShootingAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        animationHandler.SetShooting(false);
    }

    private void Eject()
    {
        Quaternion bulletRotation = ejectSpawnPosition.transform.rotation;

        GameObject newBullet = Instantiate(ejectPrefab, ejectSpawnPosition.transform.position, bulletRotation);

        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 bulletDirection = ejectSpawnPosition.transform.right;
            rb.linearVelocity = bulletDirection * Random.Range(2, 10);
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        animationHandler.SetReloading(true);

        yield return new WaitForSeconds(reloadTime);

        gunnerAmmo = gunnerMaxAmmo;

        animationHandler.SetReloading(false);
        isReloading = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerAbility.isCloakActive)
            {
                variables.TemporarilyDetectPlayer();
            }
            else
            {
                variables.isEnemyAlerted = true;
                variables.isPlayerDetected = true;
            }
        }
        if (collision.gameObject.CompareTag("IceBullet"))
        {
            isHitByIce = true;
        }
    }

}
