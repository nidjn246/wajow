using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool isGrounded;
    [SerializeField] public bool isOnWall;
    [SerializeField] public int amountOfJumps;
    [SerializeField] public int jumpsLeft;
    Vector3 direction;
    private Animator animator;
    private bool lookingLeft = true;
    void Start()
    {
        CrownManager.Instance.AddPlayer(gameObject);
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
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
        if (rb == null) return;
        if (!context.performed) return; // Only trigger once per button press

        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        else if (isOnWall && lookingLeft && jumpsLeft > 0)
        {
            animator.SetTrigger("WallJump");
            removeJump();
            direction = (Vector3.up + Vector3.right).normalized;
            rb.AddForce(direction * jumpForce * 1.7f, ForceMode.Impulse);
        }
        else if (isOnWall && !lookingLeft && jumpsLeft > 0)
        {
            animator.SetTrigger("WallJump");
            removeJump();
            direction = (Vector3.up + Vector3.left).normalized;
            rb.AddForce(direction * jumpForce * 1.7f, ForceMode.Impulse);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 normal = contact.normal;
        if (Vector3.Dot(normal, Vector3.up) > 0.5f)
        {
            isGrounded = true;
            jumpsLeft = amountOfJumps;
        }


        if (Vector3.Dot(normal, Vector3.left) > 0.5f)
        {
            isOnWall = true;
        }
        else if (Vector3.Dot(normal, Vector3.right) > 0.5f)
        {
            isOnWall = true;
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
