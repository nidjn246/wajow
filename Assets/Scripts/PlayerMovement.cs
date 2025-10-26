using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveInput;
    private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    private Vector3 counterMovement;
    [SerializeField] private float counterMovementForce = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CrownManager.Instance.AddPlayer(gameObject);
    }

    void FixedUpdate()
    {

        counterMovement = new Vector3(-rb.linearVelocity.x * counterMovementForce, 0, rb.linearVelocity.z * counterMovementForce);
        rb.AddForce(new Vector3(moveInput, 0, 0) * speed + counterMovement);



    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;
    }
}
