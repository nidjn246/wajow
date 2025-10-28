using UnityEngine;

public class SendPlayersToSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawns;
    void Start()
    {
        for (int i = 0; i < CrownManager.Instance.players.Count; i++)
        {
            CrownManager.Instance.players[i].transform.position = spawns[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
