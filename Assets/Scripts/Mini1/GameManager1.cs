using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    static GameManager1 gameManager;

    public static GameManager1 Instance { get { return gameManager; } }

    private int currentScore = 0;

    public bool isGameStart;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }
    private void Awake()
    {
        gameManager = this;
        uiManager = FindAnyObjectByType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        isGameStart = false;
    }

    public void StartGame()
    {
        uiManager.CloseReadyCanvas();
        isGameStart = true;
    }

    public void GameOver()
    {
        uiManager.ShowGameOverCanvas();
        //playerprefabµÓ¿Â
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }
}
