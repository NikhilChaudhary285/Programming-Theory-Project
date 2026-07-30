using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private Counter counter;

    void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("UIManager could not find a GameManager instance in the scene.");
            return;
        }
        else
        {
            GameManager.Instance.OnTimerChanged += HandleTimerChanged;
            GameManager.Instance.OnGameOver += HandleGameOver;
        }
    }

    void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnTimerChanged -= HandleTimerChanged;
            GameManager.Instance.OnGameOver -= HandleGameOver;
        }
    }

    private int _lastDisplayedSeconds = -1;
    void HandleTimerChanged(float timeRemaining)
    {
        int displaySeconds = Mathf.CeilToInt(timeRemaining);

        if (displaySeconds == _lastDisplayedSeconds) return; // skip redundant UI updates
        _lastDisplayedSeconds = displaySeconds;

        timerText.text = "Time: " + displaySeconds;
        timerText.color = displaySeconds <= 10 ? Color.red : Color.white;
    }

    void HandleGameOver()
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Time's Up!\nFinal Score: " + counter.Score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}