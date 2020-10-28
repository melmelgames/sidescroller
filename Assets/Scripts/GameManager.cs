using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    
    private static GameManager instance;
    private static bool gameOver;

    private void Awake() {
        instance = this;
        gameOver = false;
        Time.timeScale = 0.0f;
        Health.InitializeStatic();
        Score.InitializeStatic();
    }

    private void Update()
    {
        int health = Health.GetHealth();
        if(health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOver = true;
        GameOverWindow.ShowStatic();
    }

    public static void GameOverStatic()
    {
        instance.GameOver();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1.0f;
        gameOver = false;
    }

    public static void ResumeGameStatic()
    {
        instance.ResumeGame();
        ScoreWindow.ShowStatic();
    }
}
