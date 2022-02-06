using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private static SceneManager _instance;

    private ScoreKeeper _scoreKeeper;
    private void Awake()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
            _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        }
    }

    public void StartGame()
    {
        LoadScene(1);
    }

    public void Restart()
    {
        _scoreKeeper.ResetScore();
        StartGame();
    }

    public void ReloadGame()
    {
        //LoadScene(1);
        LoadScene(0);
    }

    public void GoToMainMenu()
    {
        LoadScene(0);
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
