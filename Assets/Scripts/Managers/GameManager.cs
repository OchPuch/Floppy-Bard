using System;
using DataBase;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Difficulty CurrentDifficulty = Difficulties.Hard;
    [Header("Pillars")]
    [SerializeField]
    private Transform pillarSpawnPoint;
    [SerializeField]
    private GameObject pillarPrefab;
    private float _pillarSpawnTimer = 100;
    
    [Header("Score")]
    public bool highScoreBeaten = false;
    public int score;
    
    [HideInInspector]
    public bool isGameOver = false;
    [HideInInspector]
    public bool isGameStarted = false;
    
    public Action OnScore;
    public Action OnGameOver;
    public Action OnHighScoreBeaten;
    public Action OnGameStarted;

    private void Awake()
    {
        
        if (!Instance) Instance = this;
        else Destroy(gameObject);
        Application.targetFrameRate = 150;
        OnScore += Scored;
        OnGameOver += GameOver;
        OnGameStarted += OnGameStart;
        
        CurrentDifficulty = Preferences.GetDifficulty();
        
    }
    
    private void Update()
    {
        if (!isGameStarted) return;
        _pillarSpawnTimer += Time.deltaTime;
        if (_pillarSpawnTimer >= CurrentDifficulty.PillarSpawnTime)
        {
            _pillarSpawnTimer = 0;
            SpawnPillar();
        }
    }
    
  
    private void SpawnPillar()
    {
        Instantiate(pillarPrefab, pillarSpawnPoint.position, Quaternion.identity);
    }

    private void Scored()
    {
        score++;
        int highScore = DataBase.DataBase.GetHighScore();
        if (score > highScore)
        {
            DataBase.DataBase.SetHighScore(score);
            if (!highScoreBeaten && highScore != 0)
            {
                OnHighScoreBeaten?.Invoke();
                highScoreBeaten = true;
            }
        }
    }

    private void OnGameStart()
    {
        isGameStarted = true;
    }
    
    public void GameOver()
    {
        PauseGame();
        isGameOver = true;
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Reset()
    {
        score = 0;
        highScoreBeaten = false;
    }

    public void ChangeDifficulty(Difficulty difficulty)
    {
        CurrentDifficulty = difficulty;
        Preferences.SetDifficulty(difficulty);
        RestartGame();
    }

    public void ChangeDifficultyToEasy()
    {
        ChangeDifficulty(Difficulties.Easy);
    }
    
    public void ChangeDifficultyToNormal()
    {
        ChangeDifficulty(Difficulties.Normal);
    }
    
    public void ChangeDifficultyToHard()
    {
        ChangeDifficulty(Difficulties.Hard);
    }
    
}