using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float acceleration = 5f;
    public float deceleration = 5f;
    private float currentSpeed = 0f;
    private Rigidbody2D rb;
    public Camera cam;

    private Vector2 movementInput;
    private Vector2 mousePos;

    AnimationHandler animationHandler;

    NavMeshAgent agent;
    [SerializeField] Vector3 coverTarget;
    private GameObject coversParent;
    [SerializeField] SpriteRenderer[] covers;
    public bool isCovering = false;
    public bool isInCoverMode = false;
    public bool isMovingToCover = false;
    public bool isHoldingSpace = false;
    [SerializeField] BoxCollider2D coverCollider;
    private string currentCoverTag;
    [SerializeField] LayerMask coverLayer;
    [SerializeField] private float coverSearchRadius = 5f;

    GlobalVariables variables;

    PlayerHp playerHp;

    Customization custom;
    LevelControl levelControl;
    public float coverHealTime = 1f;
    private float timer;

    private Vector3 startPosition;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        playerHp = GetComponent<PlayerHp>();

        custom = FindFirstObjectByType<Customization>();
        levelControl = FindFirstObjectByType<LevelControl>();

        InitializeVars();
        startPosition = transform.position;
    }

    private void InitializeVars()
    {
        rb = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        coversParent = GameObject.FindGameObjectWithTag("Covers");
        covers = coversParent.GetComponentsInChildren<SpriteRenderer>();

        variables = FindFirstObjectByType<GlobalVariables>();
    }

    void Update()
    {
        if (!variables.isIntro)
        {
            movementInput = Vector2.zero;

            if (Input.GetKey(KeyCode.W)) movementInput.y = 1;
            if (Input.GetKey(KeyCode.S)) movementInput.y = -1;
            if (Input.GetKey(KeyCode.A)) movementInput.x = -1;
            if (Input.GetKey(KeyCode.D)) movementInput.x = 1;

            movementInput = movementInput.normalized;

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            

            if (Input.GetKey(KeyCode.Mouse1))
            {
                isHoldingSpace = true;

                foreach (SpriteRenderer cover in covers)
                {
                    Light2D light = cover.GetComponentInChildren<Light2D>();
                    FadeInSprite(cover, light);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    ClickOnCover();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.C) && !isCovering)
                {
                    MoveToClosestCover();
                }
                isHoldingSpace = false;

                foreach (SpriteRenderer cover in covers)
                {
                    Light2D light = cover.GetComponentInChildren<Light2D>();
                    FadeOutSprite(cover, light);
                }
            }

            animationHandler.SetWalking(movementInput.magnitude > 0);
        }
        else
        {
            BackToStartPos();
        }
    }

    public void BackToStartPos()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;

        coverTarget = Vector3.zero;
        isCovering = false;
        isMovingToCover = false;
        isInCoverMode = false;
        agent.enabled = false;
        animationHandler.SetCover(false);
    }


    void FixedUpdate()
    {
        if (movementInput.magnitude > 0 && !isMovingToCover)
        {
            agent.enabled = false;
            isCovering = false;
            isInCoverMode = false;
            coverCollider.enabled = false;
            currentSpeed += acceleration * Time.fixedDeltaTime;
        }
        else
        {
            currentSpeed -= deceleration * Time.fixedDeltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, moveSpeed);
        rb.linearVelocity = movementInput * currentSpeed;
        Vector2 lookDir;
        if (isCovering)
        {
            if (variables.isPlayerDetected)
            {
                coverCollider.gameObject.layer = LayerMask.NameToLayer("CoverCollider");
            }
            else
            {
                coverCollider.gameObject.layer = LayerMask.NameToLayer("NoSeeCover");
            }

            float distanceToCover = Vector2.Distance(rb.position, coverTarget);

            if (distanceToCover < 1f)
            {
                if (custom.coverHeal)
                {
                    if (isInCoverMode)
                    {
                        timer += Time.deltaTime;
                        if (timer > coverHealTime)
                        {
                            if (levelControl.playerHp < playerHp.playerMaxHp)
                            {
                                StartCoroutine(playerHp.PlusHp());
                                levelControl.playerHp += 1f;
                                timer = 0f;
                            }
                        }
                    }
                    else
                    {
                        timer = 0f;
                    }
                }
                coverCollider.enabled = true;
                isMovingToCover = false;

                animationHandler.SetCover(true);
                animationHandler.SetRun(false);
                animationHandler.SetSlide(false);

                switch (currentCoverTag)
                {
                    case "CoverUp":
                        rb.rotation = 0f;
                        break;
                    case "CoverDown":
                        rb.rotation = 180f;
                        break;
                    case "CoverRight":
                        rb.rotation = -90f;
                        break;
                    case "CoverLeft":
                        rb.rotation = 90f;
                        break;
                }
                return;
            }
            else if (distanceToCover < 3f)
            {
                agent.speed = 4f;
                animationHandler.SetCover(false);
                animationHandler.SetRun(false);
                animationHandler.SetSlide(true);

                lookDir = (Vector2)coverTarget - rb.position;
            }
            else
            {
                agent.speed = 6f;
                animationHandler.SetCover(false);
                animationHandler.SetSlide(false);
                animationHandler.SetRun(true);

                lookDir = (Vector2)coverTarget - rb.position;
            }
        }
        else
        {
            coverCollider.enabled = false;
            animationHandler.SetCover(false);
            animationHandler.SetSlide(false);
            animationHandler.SetRun(false);
            lookDir = mousePos - rb.position;
        }

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void ClickOnCover()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, coverLayer);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("CoverUp") || hit.collider.CompareTag("CoverDown") || hit.collider.CompareTag("CoverLeft") || hit.collider.CompareTag("CoverRight"))
            {
                Debug.Log("Geklikt op: " + hit.collider.name);
                currentCoverTag = hit.collider.tag;
                isCovering = true;
                isMovingToCover = true;
                isInCoverMode = true;
                coverTarget = hit.transform.position;
                agent.enabled = true;
                agent.SetDestination(coverTarget);
                animationHandler.SetRun(true);
            }
            else
            {
                Debug.Log("Geklikt op een niet-geldig object: " + hit.collider.name);
            }
        }
        else
        {
            Debug.Log("Geen object geraakt.");
        }
    }

    private void MoveToClosestCover()
    {
        Collider2D[] covers = Physics2D.OverlapCircleAll(transform.position, coverSearchRadius, coverLayer);

        if (covers.Length == 0)
        {
            Debug.Log("Geen cover gevonden binnen radius.");
            return;
        }

        Transform closestCover = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D cover in covers)
        {
            float distance = Vector2.Distance(transform.position, cover.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestCover = cover.transform;
            }
        }

        if (closestCover != null)
        {
            currentCoverTag = closestCover.tag;
            Debug.Log("Dichtstbijzijnde cover: " + closestCover.name + " | Tag: " + currentCoverTag);

            coverTarget = closestCover.position;
            isCovering = true;
            isMovingToCover = true;
            isInCoverMode = true;
            agent.enabled = true;
            agent.SetDestination(coverTarget);
            animationHandler.SetRun(true);
        }
    }

    private void FadeInSprite(SpriteRenderer spriteRenderer, Light2D light)
    {
        Color spriteColor = spriteRenderer.color;

        if (spriteColor.a < 1f)
        {
            spriteColor.a += Time.deltaTime * 3f;
            spriteRenderer.color = spriteColor;
        }

        if (light.intensity < 1f)
        {
            light.intensity += Time.deltaTime * 3f;
        }
        else
        {
            light.intensity = 1f;
        }
    }

    private void FadeOutSprite(SpriteRenderer spriteRenderer, Light2D light)
    {
        Color spriteColor = spriteRenderer.color;

        if (spriteColor.a > 0f)
        {
            spriteColor.a -= Time.deltaTime * 3f;
            spriteRenderer.color = spriteColor;
        }

        if (light.intensity > 0f)
        {
            light.intensity -= Time.deltaTime * 3f;
        }
        else
        {
            light.intensity = 0f;
        }
    }
}
