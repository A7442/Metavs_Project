using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    static GameManager1 gameManager;

    public static GameManager1 Instance { get { return gameManager; } }

    private int currentScore = 0;
    private void Awake()
    {
        gameManager = this;
    }

    public void GameOver()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }
}
