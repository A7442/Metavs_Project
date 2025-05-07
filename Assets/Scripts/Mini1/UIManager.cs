using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Text finalText;

    public Canvas rankCanvas;
    public Canvas gameReadyCanvas;
    public Canvas gameOverCanvas;

    void Start()
    {
        rankCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void CloseReadyCanvas()
    {
        gameReadyCanvas.gameObject.SetActive(false);
    }

    public void ShowRankCanvas()
    {
        rankCanvas.gameObject.SetActive(true);
    }

    public void ExitRankCanvas()
    {
        rankCanvas.gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowGameOverCanvas()
    {
        finalText.text = scoreText.text;
        gameOverCanvas.gameObject.SetActive(true);
    }
}
