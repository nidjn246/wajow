using UnityEngine;

public class StealCrown : MonoBehaviour
{
    [SerializeField] private GameObject crown;
    private Renderer meshRenderer;
    [SerializeField] private float cooldownTime = 3f;
    [SerializeField] private bool isReturning = false;


    [SerializeField] private float timer;
    void Start()
    {
        meshRenderer = GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()


    {
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
            meshRenderer.material.color = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g, meshRenderer.material.color.b, 1f);
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
        meshRenderer.material.color = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g, meshRenderer.material.color.b, 0.3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CrownPlayer") && CrownManager.Instance.canSteal == true)
        {

            CrownManager.Instance.whoHasCrown = this.gameObject;
            StartCooldown();
            collision.gameObject.tag = "Player";
            gameObject.layer = LayerMask.NameToLayer("Cooldown");

        }
    }
}
