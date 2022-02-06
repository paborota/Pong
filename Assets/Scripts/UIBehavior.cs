using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBehavior : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score1;
    [SerializeField] private TextMeshProUGUI score2;

    private ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        if (_scoreKeeper == null)
        {
            Debug.Log("UIBehavior: Could not find ScoreKeeper object.");
        }
        else
        {
            _scoreKeeper.SetupUIBehaviorLink(this);
        }
        
        if (score1 != null)
        {
            score1.text = _scoreKeeper.Player1CurrentScore.ToString();
        }
        if (score2 != null)
        {
            score2.text = _scoreKeeper.Player2CurrentScore.ToString();
        }
    }

    public void UpdatePlayer1Score()
    {
        if (_scoreKeeper == null)
        {
            Debug.Log("UIBehavior: Score Keeper object null reference.");
            return;
        }

        if (score1 == null) return;
        score1.text = _scoreKeeper.Player1CurrentScore.ToString();
    }
    
    public void UpdatePlayer2Score()
    {
        if (_scoreKeeper == null)
        {
            Debug.Log("UIBehavior: Score Keeper object null reference.");
            return;
        }
        
        if (score2 == null) return;
        score2.text = _scoreKeeper.Player2CurrentScore.ToString();
    }
}
