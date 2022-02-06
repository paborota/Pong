using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int scoreToWin = 5;
    
    public int Player1CurrentScore { get; private set; }
    public int Player2CurrentScore { get; private set; }
    
    public int WinningPlayerID { get; private set; }

    private UIBehavior _uiBehavior;
    private SceneManager _sceneManager;

    private static ScoreKeeper _instance;
    
    private void Awake()
    {
        if (!CheckSingleton()) return;
        
        _sceneManager = FindObjectOfType<SceneManager>();
        if (_sceneManager == null)
        {
            Debug.Log("ScoreKeeper: Could not find custom SceneManager object.");
        }
    }
    
    private bool CheckSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            return false;
        }

        DontDestroyOnLoad(gameObject);
        _instance = this;
        return true;
    }

    public void SetupUIBehaviorLink(UIBehavior uiBehavior)
    {
        _uiBehavior = uiBehavior;
    }

    private void IncrementScore(int playerID)
    {
        switch (playerID)
        {
            case 1 when _uiBehavior != null:
                ++Player1CurrentScore;
                _uiBehavior.UpdatePlayer1Score();
                break;
            case 2 when _uiBehavior != null:
                ++Player2CurrentScore;
                _uiBehavior.UpdatePlayer1Score();
                break;
        }
    }

    public void ResetScore()
    {
        Player1CurrentScore = 0;
        Player2CurrentScore = 0;
    }

    private void CheckForWinner(int playerID)
    {
        switch (playerID)
        {
            case 1 when Player1CurrentScore >= scoreToWin:
                WinningPlayerID = 1;
                _sceneManager.EndGame();
                break;
            case 2 when Player2CurrentScore >= scoreToWin:
                WinningPlayerID = 2;
                _sceneManager.EndGame();
                break;
        }
    }

    public void Goal(int playerID)
    {
        IncrementScore(playerID);

        CheckForWinner(playerID);

        if (_sceneManager == null) return;
        _sceneManager.ReloadGame();
    }
}
