using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public ScoreSystem SS;
    public int Score;
    public int HighScore = 0;
    public Text HighScoreTextEnd;
    public Text HighScoreTextEndOutline;

    void Start()
    {
        Time.timeScale = 1.0f;
        HighScore = PlayerPrefs.GetInt("HighScore");
    }

    void Update()
    {
        Score = SS.Score;

        HighScoreTextEnd.text = "HIGHSCORE: " + HighScore.ToString("0000");
        HighScoreTextEndOutline.text = "HIGHSCORE: " + HighScore.ToString("0000");

        if (Score > HighScore)
        {
            Debug.Log("Congrats! New High Score!");
            HighScore = Score;
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
        if(Score > HighScore)
        {
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
