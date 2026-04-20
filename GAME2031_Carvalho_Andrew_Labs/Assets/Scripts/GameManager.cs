using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI missedText;

    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverPanel;
    private int missedObjects = 0;
    private const int maxMissedObjects = 30;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ObjectMissed()
    {
        missedObjects++;
        missedText.text = $"Missed: {missedObjects}/{maxMissedObjects}";
        if (missedObjects >= maxMissedObjects)
            GameOver();
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AwardPoints(int points)
    {
        FindObjectOfType<PlayerController>().IncrementScore(points);
    }
}