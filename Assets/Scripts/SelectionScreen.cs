using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectionScreen : MonoBehaviour
{
    private PlayerInputManager PlayerInputManager;

    void Start()
    {
        PlayerInputManager = FindFirstObjectByType<PlayerInputManager>();
    }

    private void Update()
    {

    }

    public void StartGame()
    {

        SceneManager.LoadScene("SampleScene");

        CrownManager.Instance.StartGame();
        PlayerInputManager.DisableJoining();

    }
}
