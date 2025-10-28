using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerDuration = 60;
    private float timer;
    bool ended = false;
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
            CrownManager.Instance.players[i].GetComponent<PlayerMovement>().enabled = false;
            CrownManager.Instance.players[i].GetComponent<Jump>().enabled = false;

        }
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("SelectionScreen");
    }
}
