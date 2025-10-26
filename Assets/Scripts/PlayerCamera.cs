using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerCamera : MonoBehaviour
{
    private GameObject cam;
    private PlayerMovement playerMovement;
    PlayerInputManager playerInputmanager;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        playerMovement = GetComponent<PlayerMovement>();
        playerInputmanager = FindFirstObjectByType<PlayerInputManager>();
        cam = GetComponentInChildren<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SelectionScreen")
        {
            playerInputmanager.splitScreen = false;
            playerMovement.enabled = false;
            cam.SetActive(false);
        }
        else
        {
            playerInputmanager.splitScreen = true;
            playerMovement.enabled = true;
            cam.SetActive(true);
        }
    }
}
