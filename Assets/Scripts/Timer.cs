using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerDuration = 60;
    [SerializeField] private float timer;
    [SerializeField] GameObject border;
    bool ended = false;
    [SerializeField] GameObject winPlayerScreen;
    private TextMeshProUGUI textBox;

    void Start()
    {
        textBox = GetComponentInChildren<TextMeshProUGUI>();
        timer = timerDuration;

    }

    // Update is called once per frame
    void Update()
    {
        if (ended) return;
        timer -= Time.deltaTime;

        textBox.text = ((int)timer).ToString();

        if (timer <= 0)
        {
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        ended = true;
        for (int i = 0; i < CrownManager.Instance.players.Count; i++)
        {
            winPlayerScreen.SetActive(true);
            border.SetActive(false);
            Destroy(CrownManager.Instance.players[i]);
            Destroy(GameManager.Instance.gameObject);
            Destroy(FindFirstObjectByType<PlayerInputManager>().gameObject);
            textBox.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("SelectionScreen");
    }
}
