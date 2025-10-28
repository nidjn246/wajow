using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectionScreen : MonoBehaviour
{
    private PlayerInputManager PlayerInputManager;
    [SerializeField] GameObject startButton;

    void Start()
    {
        PlayerInputManager = FindFirstObjectByType<PlayerInputManager>();
    }

    private void Update()
    {
        if (PlayerInputManager.playerCount >= 2)
        {
            startButton.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");

        CrownManager.Instance.StartGame();
        PlayerInputManager.DisableJoining();

    }
}
