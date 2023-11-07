using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;

    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
        animator.SetBool("isGrounded", isGrounded);
    }

    public void MovePlayer(float direction, bool isJumpBtnPressed)
    {
        if(isJumpBtnPressed)
            Jump();
        if (Mathf.Abs(direction) > 0.01f)
        { 
            HorizontalMovement(direction);
            FlipPlayer(direction);
        }

        animator.SetBool("isRunning", Mathf.Abs(direction) > 0.01f);
    }

    private void Jump()
    {
        if(isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetBool("isGrounded", false);
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(curve.Evaluate(direction), rb.velocity.y);
    }

    private void FlipPlayer(float direction)
    {
        if (direction > 0.01f)
            transform.localScale = new Vector2(1, 1);
        else if (direction < -0.01f)
            transform.localScale = new Vector2(-1, 1);
    }

}
