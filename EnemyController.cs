using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private ICombat combat;
    private EnemyMovement movement;

    [SerializeField] Transform target;

    private enum State { Roaming, Engaging }
    private State currentState;

    [Header("Roam Time")]
    [SerializeField] private float roamMinTime = 4f;
    [SerializeField] private float roamMaxTime = 10f;

    [Header("Engage Time")]
    [SerializeField] private float engageMinTime = 3f;
    [SerializeField] private float engageMaxTime = 6f;

    private float stateTimer;

    void Awake()
    {
        GameObject player = GameObject.FindFirstObjectByType<PlayerController>()?.gameObject;

        if (player != null)
        {
            target = player.transform;
        }

        movement = GetComponent<EnemyMovement>();
        combat = GetComponent<ICombat>();
    }

    void Start()
    {
        StartRoam();
    }

    void FixedUpdate()
    {
        if (target == null) return;

        stateTimer -= Time.fixedDeltaTime;

        switch (currentState)
        {
            case State.Roaming:
                movement.Roam();
                if (stateTimer <= 0) StartEngage();
                break;

            case State.Engaging:
                movement.Engage(target);
                combat.HandleCombat(target);

                if (stateTimer <= 0) StartRoam();
                break;
        }
    }

    void StartRoam()
    {
        currentState = State.Roaming;
        stateTimer = Random.Range(roamMinTime, roamMaxTime);
        movement.StartRoam();
    }

    void StartEngage()
    {
        currentState = State.Engaging;
        stateTimer = Random.Range(engageMinTime, engageMaxTime);
    }
}