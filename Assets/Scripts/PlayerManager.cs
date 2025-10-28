using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetSpawn(PlayerInput player)
    {
        player.transform.position = spawnPoints[player.playerIndex].position + new Vector3(0, 1.5f, 0);

    }


}
