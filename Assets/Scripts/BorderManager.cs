using UnityEngine;

public class BorderManager : MonoBehaviour
{
    [SerializeField] private GameObject borderPrefab2;
    [SerializeField] private GameObject borderPrefab4;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CrownManager.Instance.players.Count == 2)
        {
            borderPrefab2.SetActive(true);
        }
        else if (CrownManager.Instance.players.Count > 2)
        {
            borderPrefab4.SetActive(true);
        }
    }
}
