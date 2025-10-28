using UnityEngine;

public class StealCrown : MonoBehaviour
{
    [SerializeField] public GameObject crown;
    [SerializeField] private float cooldownTime = 3f;
    [SerializeField] private bool isReturning = false;

    Jump jumpScript;
    [SerializeField] private float timer;
    private void Awake()
    {

    }
    void Start()
    {

        jumpScript = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()


    {
        if (CrownManager.Instance.whoHasCrown == this.gameObject)
        {
            jumpScript.amountOfJumps = 2;

        }
        else if (CrownManager.Instance.whoHasCrown != this.gameObject)
        {
            jumpScript.amountOfJumps = 1;

        }
        if (isReturning == true)
        {
            timer -= Time.deltaTime;
            //timer = Mathf.Clamp(timer, 0f, cooldownTime);

        }


        ReturnToNormal();

        UpdateCrown();
    }

    void ReturnToNormal()
    {
        if (timer <= 0)
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
            isReturning = false;
            CrownManager.Instance.canSteal = true;
        }
    }

    private void UpdateCrown()
    {
        if (CrownManager.Instance.whoHasCrown == this.gameObject)
        {

            crown.SetActive(true);
        }
        else
        {
            crown.SetActive(false);
        }
    }

    void StartCooldown()
    {

        CrownManager.Instance.canSteal = false;
        timer = cooldownTime;
        isReturning = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CrownPlayer") && CrownManager.Instance.canSteal == true)
        {
            CrownManager.Instance.whoHasCrown = this.gameObject;
            StartCooldown();
            collision.gameObject.tag = "Player";
            gameObject.layer = LayerMask.NameToLayer("Cooldown");
            jumpScript.jumpsLeft = jumpScript.amountOfJumps;
        }
    }
}
