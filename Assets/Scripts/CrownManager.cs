using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CrownManager : MonoBehaviour
{
    public GameObject whoHasCrown;
    public bool canSteal = true;
    PlayerInputManager playerInputManager;
    [SerializeField] public List<GameObject> players;
    static public CrownManager Instance { get; private set; }
    private void Awake()
    {
        playerInputManager = FindFirstObjectByType<PlayerInputManager>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPlayer(GameObject player)
    {
        players.Add(player);
    }



    public void StartGame()
    {
        whoHasCrown = players[Random.Range(0, players.Count)];
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (whoHasCrown == null) return;
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            whoHasCrown.gameObject.tag = "CrownPlayer";
        }
    }
}
