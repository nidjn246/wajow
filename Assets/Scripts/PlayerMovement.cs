using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveInput;
    private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    private Vector3 counterMovement;
    Animator animator;
    GameObject skin;
    Jump jumpScript;
    [SerializeField] private float counterMovementForce = 0.5f;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        jumpScript = GetComponent<Jump>();
        rb = GetComponent<Rigidbody>();
        if (CrownManager.Instance.whoHasCrown == gameObject)
        {
            jumpScript.amountOfJumps = 2;
            jumpScript.jumpsLeft = jumpScript.amountOfJumps;
        }
        else
        {
            jumpScript.amountOfJumps = 1;
            jumpScript.jumpsLeft = jumpScript.amountOfJumps;
        }
        skin = GetComponentInChildren<Animator>().gameObject;
    }

    void FixedUpdate()
    {
        animator.SetBool("OnWall", jumpScript.isOnWall);
        counterMovement = new Vector3(-rb.linearVelocity.x * counterMovementForce, 0, rb.linearVelocity.z * counterMovementForce);
        rb.AddForce(new Vector3(moveInput, 0, 0) * speed + counterMovement);

        if (rb.linearVelocity.x > 0.1f)
        {
            skin.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (rb.linearVelocity.x < -0.1f)
        {
            skin.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {

        moveInput = context.ReadValue<Vector2>().x;
        if (animator == null) return;
        if (context.performed)
        {
            animator.SetBool("Walking", true);
        }
        if (context.canceled)
        {
            animator.SetBool("Walking", false);
        }
    }
}
