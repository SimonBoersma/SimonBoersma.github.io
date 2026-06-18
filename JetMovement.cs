using UnityEngine;

public class JetMovement : MonoBehaviour, IMovement
{
    [Header("Movement Stats")]
    public float maxSpeed = 30f;
    [SerializeField] private float rotationSpeed = 800f;

    [Header("Gravity")]
    [SerializeField] public float gravityAtLowSpeed = 10f;
    [SerializeField] public float gravityAtHighSpeed = 0.1f;

    private Rigidbody2D rb;

    private float currentSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public float CurrentSpeed => currentSpeed;
    public float RotationSpeed => rotationSpeed;
    public bool UsesForwardMovement => true;
    public Vector2 Forward => transform.right;


    public void SetVelocity(Vector2 velocity)
    {
        rb.linearVelocity = velocity;
        currentSpeed = velocity.magnitude;

        ApplyGravity();
    }

    public void Rotate(float angle)
    {
        rb.MoveRotation(angle);
    }

    public void Move(Vector2 direction, float speedPercent)
    {
        currentSpeed = maxSpeed * Mathf.Clamp01(speedPercent);

        Vector2 targetVelocity = direction.normalized * currentSpeed;

        rb.linearVelocity = targetVelocity;

        float angle =
            Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        rb.MoveRotation(
            Mathf.MoveTowardsAngle(
                rb.rotation,
                angle,
                rotationSpeed * Time.deltaTime
            )
        );

        ApplyGravity();
    }

    private void ApplyGravity()
    {
        float t = currentSpeed / maxSpeed;

        rb.gravityScale = Mathf.Lerp(
            gravityAtLowSpeed,
            gravityAtHighSpeed,
            t
        );
    }
}