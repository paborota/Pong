using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void StartGame()
    {
        LoadScene(1);
    }

    public void Restart()
    {
        ResetScore();
        StartGame();
    }

    public void ReloadGame()
    {
        LoadScene(1);
    }

    public void GoToMainMenu()
    {
        ResetScore();
        LoadScene(0);
    }

    private void ResetScore()
    {
        var scoreKeeper = FindObjectOfType<ScoreKeeper>();
        if (scoreKeeper != null)
        {
            scoreKeeper.ResetScore();
        }
    }

    public void EndGame()
    {
        LoadScene(2);
    }

    private void LoadScene(int buildIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
