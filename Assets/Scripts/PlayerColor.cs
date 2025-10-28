using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerColor : MonoBehaviour
{
    PlayerInput playerInput;
    StealCrown stealCrown;
    [SerializeField] private GameObject[] skins;
    [SerializeField] private GameObject[] heads;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private CinemachineBrain brain;
    void Start()
    {
        playerInput = FindFirstObjectByType<PlayerInput>();
        stealCrown = GetComponent<StealCrown>();
        SetCameraSettings();
    }
    void SetCameraSettings()
    {
        switch (playerInput.playerIndex)
        {
            case 0:
                stealCrown.crown.transform.SetParent(heads[0].transform);
                playerInput.gameObject.name = "Player1";
                skins[0].SetActive(true);
                brain.ChannelMask = OutputChannels.Channel01;
                playerCamera.OutputChannel = OutputChannels.Channel01;
                break;
            case 1:
                stealCrown.crown.transform.SetParent(heads[1].transform);
                skins[1].SetActive(true);
                playerInput.gameObject.name = "Player2";
                brain.ChannelMask = OutputChannels.Channel02;
                playerCamera.OutputChannel = OutputChannels.Channel02;
                break;
            case 2:
                stealCrown.crown.transform.SetParent(heads[2].transform);
                skins[2].SetActive(true);
                playerInput.gameObject.name = "Player3";
                brain.ChannelMask = OutputChannels.Channel03;
                playerCamera.OutputChannel = OutputChannels.Channel03;
                break;
            case 3:
                stealCrown.crown.transform.SetParent(heads[3].transform);
                skins[3].SetActive(true);
                playerInput.gameObject.name = "Player4";
                brain.ChannelMask = OutputChannels.Channel04;
                playerCamera.OutputChannel = OutputChannels.Channel04;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
