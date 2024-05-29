using UnityEngine;
using TMPro;

public class displayTimeLimit : MonoBehaviour
{
    [SerializeField] private float countDownSeconds;  // 3 minutes in seconds
    [SerializeField] public TextMeshProUGUI timeLimitText;
    [SerializeField] public GameObject gameView;
    [SerializeField] public GameObject loseView;

    private void Start()
    {
        UpdateTimeDisplay(countDownSeconds);
    }

    void Update()
    {
        countDownSeconds -= Time.deltaTime;

        if (countDownSeconds > 0)
        {
            UpdateTimeDisplay(countDownSeconds);
        }
        else
        {
            timeLimitText.text = "Game over";
            gameView.SetActive(false);
            loseView.SetActive(true);
        }
    }

    private void UpdateTimeDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timeLimitText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}

