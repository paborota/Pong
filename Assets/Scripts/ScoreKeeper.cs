using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int scoreToWin = 1;
    
    public int Player1CurrentScore { get; private set; }
    public int Player2CurrentScore { get; private set; }
    
    public int WinningPlayerID { get; private set; }

    private UIBehavior _uiBehavior;

    private static ScoreKeeper _instance;
    
    private void Awake()
    {
        CheckSingleton();
    }
    
    private void CheckSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            return;
            //return false;
        }

        DontDestroyOnLoad(gameObject);
        _instance = this;
        //return true;
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
                _uiBehavior.UpdatePlayer2Score();
                break;
        }
        
        Debug.Log($"Player1: {Player1CurrentScore} | Player2: {Player2CurrentScore}");
    }

    public void ResetScore()
    {
        Player1CurrentScore = 0;
        Player2CurrentScore = 0;
    }

    private void CheckForWinner(int playerID)
    {
        var sceneManager = FindObjectOfType<SceneManager>();
        if (sceneManager == null) return;
        switch (playerID)
        {
            case 1 when Player1CurrentScore >= scoreToWin:
                WinningPlayerID = 1;
                sceneManager.EndGame();
                break;
            case 2 when Player2CurrentScore >= scoreToWin:
                WinningPlayerID = 2;
                sceneManager.EndGame();
                break;
            default:
                sceneManager.ReloadGame();
                break;
        }
    }

    public void Goal(int playerID)
    {
        IncrementScore(playerID);

        CheckForWinner(playerID);
    }
}
