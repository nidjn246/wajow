using UnityEngine;
using UnityEngine.InputSystem;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject[] icons;
    PlayerInputManager playerInputManager;

    private void Start()
    {
        playerInputManager = FindFirstObjectByType<PlayerInputManager>();
    }
    private void Update()
    {
        switch (playerInputManager.playerCount - 1)
        {
            case 0:
                icons[0].SetActive(false);
                break;
            case 1:
                icons[1].SetActive(false);
                break;
            case 2:
                icons[2].SetActive(false);
                break;
            case 3:
                icons[3].SetActive(false);
                break;

        }
    }
}
