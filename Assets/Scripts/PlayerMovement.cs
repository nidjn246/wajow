using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveInput;
    private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    private Jump jumpScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpScript = GetComponent<Jump>();
        CrownManager.Instance.AddPlayer(gameObject);
    }

    void FixedUpdate()
    {

        rb.linearVelocity = new Vector3(moveInput * speed, rb.linearVelocity.y, 0f);


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;
    }
}
