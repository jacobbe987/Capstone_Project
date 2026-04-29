using UnityEngine;

//use gravity off - collision su continuous

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private Camera mainCamera;

    [Header("Movement Attributes")]
    [SerializeField] private float speed = 2f;
    private Vector3 move;

    [Header("Jump Attributes")]
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float fallMultiplier = 2.5f;
    private float verticalVelocity = 0f;
    private int jumpCounter = 0;
    private bool canDoubleJump = true;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (groundCheck == null)
            groundCheck = GetComponentInChildren<GroundCheck>();

        if (GetComponent<Camera>() == null)
            mainCamera = Camera.main;
    }

    private void Update()
    {
        PlayerInput();
        JumpCheck();
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        ApplyFriction();
        PlayerMovement();
    }

    private void PlayerInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 verticalCam = mainCamera.transform.forward;
        verticalCam.y = 0f;
        Vector3 horizontalCam = mainCamera.transform.right;
        horizontalCam.y = 0f;

        move = (horizontal * horizontalCam + vertical * verticalCam).normalized;
    }

    private void PlayerMovement()
    {
        Vector3 velocity = move * speed;
        velocity.y = verticalVelocity;
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    private void ApplyGravity()
    {
        if (groundCheck.CheckIsGrounded() && verticalVelocity < 0.25f)
            verticalVelocity = 0; //se e' a terra mantienilo tale con valore minimo X (non si usa -9.81f perche' potrebbe causare compenetrazioni con il terreno)
        else                        //altrimenti applica la gravita' con fall multiplier se sta cadendo
        {
            float appliedGravity = (verticalVelocity < 0f) ? gravity * fallMultiplier : gravity;
            verticalVelocity += appliedGravity * Time.fixedDeltaTime;
        }
    }

    private void ApplyFriction()
    {
        if (groundCheck.CheckIsGrounded())
        {
            Vector3 vel = rb.velocity;
            vel.x *= 0.2f;
            vel.z *= 0.2f;
            rb.velocity = vel;
        }
    }

    public void JumpCheck()
    {
        if (Input.GetButtonDown("Jump") && groundCheck.CheckIsGrounded())
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);

            if (Input.GetButtonDown("Jump") && canDoubleJump && jumpCounter <= 1)
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
                jumpCounter++;

                if (groundCheck.CheckIsGrounded())
                    jumpCounter = 0;
            }
        }
    }
}