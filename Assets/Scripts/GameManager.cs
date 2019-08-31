using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public GameObject endGameScreen;
    public GameObject titleScreen;
    public GameObject inPlayScreen;
    public Button restartButton;
    public Button startButton;
    public SpawnManager spawnManager;
    private int score = 0;
    public bool gameActive = false;
    
    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        inPlayScreen.SetActive(false);
        endGameScreen.gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + score;
        gameActive = false;

    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        titleScreen.SetActive(false);
        inPlayScreen.SetActive(true);
        gameActive = true;
        spawnManager.SpawnStray();
    }
    public void SetScore(int newScore)
    {
        score = newScore;
        scoreText.text = "Score: " + score;
    }

}
