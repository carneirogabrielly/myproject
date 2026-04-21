using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public TMP_Text healthText;
    public TMP_Text endGameText;
    public AudioSource gameOverAudio;

    void Update()
    {
        GameController.Tick(Time.deltaTime);

        if (scoreText != null)
            scoreText.text = "Score: " + GameController.score + "/" + GameController.TotalCollectables;
        if (timeText != null)
            timeText.text = "Tempo: " + GameController.TimeRemaining.ToString("0.0") + "s";
        if (healthText != null)
            healthText.text = "Vida: " + GameController.health;

        if (GameController.gameOver)
        {
            if (endGamePanel != null && !endGamePanel.activeSelf)
            {
                endGamePanel.SetActive(true);
                if (gameOverAudio != null) gameOverAudio.Play();
            }

            if (endGameText != null)
            {
                string result = GameController.hasWon ? "Vitória!" : "Game Over";
                endGameText.text = result + "\nTempo: " + GameController.finalTime.ToString("0.0") + "s\nScore: " + GameController.score + "/" + GameController.TotalCollectables;
            }
        }
    }
}
