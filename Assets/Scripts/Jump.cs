using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool isGrounded;
    [SerializeField] public bool isOnWall;
    [SerializeField] private Vector3 direction;
    private bool lookingLeft = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }



    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        else if (isOnWall && lookingLeft)
        {
            direction = Vector3.up + Vector3.right.normalized;
            rb.AddForce(direction * jumpForce, ForceMode.Impulse);

        }
        else if (isOnWall && !lookingLeft)
        {
            direction = Vector3.up + Vector3.left.normalized;
            rb.AddForce(direction * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
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
            rb.linearDamping = 5;
        }
    }
}
