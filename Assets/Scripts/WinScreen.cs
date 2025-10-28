using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class WinScreen : MonoBehaviour
{
    [SerializeField] int playerWhoWon;
    [SerializeField] GameObject[] skins;
    TextMeshProUGUI winnerText;
    void Awake()
    {
        winnerText = GetComponentInChildren<TextMeshProUGUI>();
        playerWhoWon = CrownManager.Instance.whoHasCrown.GetComponent<PlayerInput>().playerIndex;
        winnerText.text = "Player " + (playerWhoWon + 1).ToString() + " Wins!";
    }

    void Update()
    {
        switch (playerWhoWon)
        {
            case 0:
                skins[0].SetActive(true);
                break;
            case 1:
                skins[1].SetActive(true);
                break;
            case 2:
                skins[2].SetActive(true);
                break;
            case 3:
                skins[3].SetActive(true);
                break;

        }
    }
}
