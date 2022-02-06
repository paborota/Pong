using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUIBehavior : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerText;
    
    private void Start()
    {
        SetWinnerText();
    }

    private void SetWinnerText()
    {
        if (winnerText == null) return;

        var scoreKeeper = FindObjectOfType<ScoreKeeper>();
        if (scoreKeeper == null) return;

        winnerText.text = $"player {scoreKeeper.WinningPlayerID} wins";
    }
}
