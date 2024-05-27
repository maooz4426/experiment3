using UnityEngine;
using TMPro;

public class displayTimeLimit : MonoBehaviour
{
    [SerializeField] private float countDownSeconds = 30f;
    [SerializeField] public TextMeshProUGUI timeLimitText;

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
        }
    }

    private void UpdateTimeDisplay(float time)
    {
        timeLimitText.text = "0 : " + Mathf.Ceil(time).ToString("0");
    }
}
