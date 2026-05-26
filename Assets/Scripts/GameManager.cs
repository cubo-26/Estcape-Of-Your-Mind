using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Awake(){
        if(Instance==null)Instance = this;
        else Destroy(gameObject);
    }
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    // Timer
    [SerializeField] private float maxTime = 60f; // Thời gian tối đa (giây)
    [SerializeField] private TextMeshProUGUI timerText;
    private float remainingTime;
    
    // Update is called once per frame
    void Update()
    {
        if (IsPlaying())
        {
            UpdateTimer();
        }
    }
    
    private void UpdateTimer()
    {
        remainingTime -= Time.deltaTime;
        
        if (remainingTime <= 0)
        {
            remainingTime = 0;
            GameOver();
            return;
        }
        
        if (timerText != null)
        {
            int minutes = (int)(remainingTime / 60f);
            int seconds = (int)(remainingTime % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    public void AddScore(int points){
        score += points;
        UpdateScore();
    }
    private void UpdateScore(){
        scoreText.text = score.ToString();
    }
    public enum GameState { Playing, GameOver, Win }
    private GameState currentState = GameState.Playing;

    [Header("UI Panels")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;

    void Start()
    {
        remainingTime = maxTime;
        UpdateScore();
        // Đảm bảo panel tắt khi bắt đầu
        if (gameOverPanel) gameOverPanel.SetActive(false);
        if (winPanel)      winPanel.SetActive(false);
    }
    public bool IsPlaying() => currentState == GameState.Playing;

    public void GameOver()
    {
        if (!IsPlaying()) return;
        currentState = GameState.GameOver;
        gameOverPanel.SetActive(true);
        AudioManager.Instance.PlayGameOverSound();
        Time.timeScale = 0f; // Đóng băng game
    }

    public void Win()
    {
        if (!IsPlaying()) return;
        currentState = GameState.Win;
        winPanel.SetActive(true);
        AudioManager.Instance.PlayWinSound();
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Nhớ reset trước khi load scene!
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
