using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool isGrounded;
    [SerializeField] public bool isOnWall;
    [SerializeField] private int amountOfJumps;
    [SerializeField] private int jumpsLeft;
    Vector3 direction;
    private bool lookingLeft = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (rb.linearVelocity.x > 0 && isOnWall == false)
        {
            lookingLeft = false;
        }
        else if (rb.linearVelocity.x < 0 && isOnWall == false)
        {
            lookingLeft = true;
        }
    }
    void removeJump()
    {
        Debug.Log("Jump used");
        jumpsLeft--;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return; // Only trigger once per button press

        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        else if (isOnWall && lookingLeft && jumpsLeft > 0)
        {
            removeJump();
            direction = (Vector3.up + Vector3.right).normalized;
            rb.AddForce(direction * jumpForce * 2.5f, ForceMode.Impulse);
        }
        else if (isOnWall && !lookingLeft && jumpsLeft > 0)
        {
            removeJump();
            direction = (Vector3.up + Vector3.left).normalized;
            rb.AddForce(direction * jumpForce * 2.5f, ForceMode.Impulse);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpsLeft = amountOfJumps;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            isOnWall = true;
            rb.linearDamping = 10;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isOnWall = false;
            rb.linearDamping = 1;
        }
    }
}
