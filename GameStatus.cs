using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // config params
    [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] TextMeshProUGUI displayLives;
    int numberOfLives = 1;

    // cached references
    Ball ball;

    // state variables
    [SerializeField] int currentScore = 0;
    bool hasStarted = true;

    // UI components
    public UnityEngine.UI.Toggle toggleAutoPlay;
    public UnityEngine.UI.Slider livesSlider;
    public UnityEngine.UI.Slider speedSlider;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        scoreText.text = "Score: " + currentScore.ToString();
        
        if (toggleAutoPlay != null)
            toggleAutoPlay.onValueChanged.AddListener((isOn) => isAutoPlayEnabled = isOn);
        livesSlider.onValueChanged.AddListener((isChanged) => numberOfLives = (int)livesSlider.value);
        speedSlider.onValueChanged.AddListener((isChanged) => gameSpeed = (int)speedSlider.value);
    }

    void Update()
    {
        displayLives.text = "Lives: " + numberOfLives.ToString();
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void Lives()
    {
        ball = FindObjectOfType<Ball>();
        ball.LockBallToPaddle();
        hasStarted = false;
        numberOfLives--;
        displayLives.text =  "Lives: " + numberOfLives.ToString();
    }

    public int NumberOfLives()
    {
        return numberOfLives;
    }

    public bool LostLife()
    {
        return hasStarted;
    }

    public void Reset_hasStarted()
    {
        hasStarted = true;
    }
}
