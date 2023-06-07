using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    
    void Start()
    {
        GameManager.Instance.OnGameOver += OnGameOver;
        
    }
    
    public void OnPause()
    {
        pauseMenu.SetActive(true);
        GameManager.Instance.PauseGame();
    }
    
    public void OnResume()
    {
        pauseMenu.SetActive(false);
        GameManager.Instance.ResumeGame();
    }
    
    public void OnRestart()
    {
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        GameManager.Instance.RestartGame();
    }
    
    public void OnGameOver()
    {
        gameOverMenu.SetActive(true);
    }
    
    public void OnQuit()
    {
        Application.Quit();
    }
}
