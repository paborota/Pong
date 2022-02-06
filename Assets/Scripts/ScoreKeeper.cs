using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score1;
    [SerializeField] private TextMeshProUGUI score2;

    public int Player1CurrentScore { get; private set; }
    public int Player2CurrentScore { get; private set; }
    
    void Awake()
    {
        if (score1 != null)
        {
            score1.text = Player1CurrentScore.ToString();
        }
        if (score2 != null)
        {
            score2.text = Player2CurrentScore.ToString();
        }
    }

    private void IncrementScore(int playerID)
    {
        switch (playerID)
        {
            case 1 when score1 != null:
                ++Player1CurrentScore;
                score1.text = Player1CurrentScore.ToString();
                break;
            case 2 when score2 != null:
                ++Player2CurrentScore;
                score2.text = Player2CurrentScore.ToString();
                break;
        }
    }

    public void Goal(int playerID)
    {
        IncrementScore(playerID);
        // @TODO reset stage
    }
}
