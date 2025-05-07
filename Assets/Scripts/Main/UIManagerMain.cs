using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerMain : MonoBehaviour
{
    public Canvas boardCanvas;
    public Text ScoreText1;
    public Text ScoreText2;
    public Text ScoreText3;
    public Text ScoreText4;
    public Text ScoreText5;
    public Text Gamename;

    private void Start()
    {
        boardCanvas.gameObject.SetActive(false);
    }
    public void SetBoard(int i)
    {
        Gamename.text = "MiniGame" + i.ToString();
        ScoreText1.text = PlayerPrefs.GetInt($"Game{i}HighScore1").ToString();
        ScoreText2.text = PlayerPrefs.GetInt($"Game{i}HighScore2").ToString();
        ScoreText3.text = PlayerPrefs.GetInt($"Game{i}HighScore3").ToString();
        ScoreText4.text = PlayerPrefs.GetInt($"Game{i}HighScore4").ToString();
        ScoreText5.text = PlayerPrefs.GetInt($"Game{i}HighScore5").ToString();
        boardCanvas.gameObject.SetActive(true);
    }
    public void ExitBoardCanvas()
    {
        boardCanvas.gameObject.SetActive(false);
    }
}
