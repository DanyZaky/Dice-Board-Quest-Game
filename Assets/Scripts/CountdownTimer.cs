using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    private float currentTime = 600.0f; // Waktu awal dalam detik (10 menit)
    public GameObject gameoverPanel;
    public TextMeshProUGUI gameoverText;

    private void Start()
    {
        UpdateCountdownText();
        InvokeRepeating("UpdateTimer", 1.0f, 1.0f); // Memanggil UpdateTimer setiap detik
        gameoverPanel.SetActive(false);
    }

    private void UpdateTimer()
    {
        currentTime -= 1.0f;
        UpdateCountdownText();

        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    private void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        gameoverPanel.SetActive(true);
        gameoverText.text = "Waktu Habis!";
    }
}
