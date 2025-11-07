using UnityEngine;

public class BorderManager : MonoBehaviour
{
    [SerializeField] private GameObject borderPrefab2;
    [SerializeField] private GameObject borderPrefab4;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject walls;
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
            map.SetActive(true);
            walls.SetActive(false);
            borderPrefab4.SetActive(true);
        }
    }
}
