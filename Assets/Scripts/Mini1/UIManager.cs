using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text ScoreText1;
    public Text ScoreText2;
    public Text ScoreText3;
    public Text ScoreText4;
    public Text ScoreText5;
    public Text finalText;

    public Canvas rankCanvas;
    public Canvas gameReadyCanvas;
    public Canvas gameOverCanvas;

    private int[] scoreLank = new int[5];
    void Start()
    {
        rankCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
        for(int i = 0; i < scoreLank.Length; i++)
        {
            string key = $"HighScore{i + 1}";

            // 키가 없으면 0으로 초기화
            if (PlayerPrefs.HasKey(key))
            {
                scoreLank[i] = PlayerPrefs.GetInt(key);
            }
            else
            {
                scoreLank[i] = 0;
            }
        }
    }

    public void CloseReadyCanvas()
    {
        gameReadyCanvas.gameObject.SetActive(false);
    }

    public void ShowRankCanvas()
    {
        ScoreText1.text = scoreLank[0].ToString();
        ScoreText2.text = scoreLank[1].ToString();
        ScoreText3.text = scoreLank[2].ToString();
        ScoreText4.text = scoreLank[3].ToString();
        ScoreText5.text = scoreLank[4].ToString();
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

    public void ShowGameOverCanvas(int score)
    {
        finalText.text = score.ToString();
        SaveScore(score);
        gameOverCanvas.gameObject.SetActive(true);
    }

    private void SaveScore(int score)
    {
        int[] newScores = new int[scoreLank.Length + 1];
        for(int i = 0; i < scoreLank.Length; i++)
        {
            newScores[i] = scoreLank[i];
        }
        newScores[scoreLank.Length] = score;

        System.Array.Sort(newScores);
        System.Array.Reverse(newScores);

        for(int i = 0; i < scoreLank.Length; i++)
        {
            scoreLank[i] = newScores[i];
            string key = $"HighScore{i + 1}";
            PlayerPrefs.SetInt(key, scoreLank[i]);
        }
        PlayerPrefs.Save();
    }
}
