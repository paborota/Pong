using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    private ScoreKeeper _scoreKeeper;

    [SerializeField] [Range(1, 2)] private int owningPlayerID;

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        if (_scoreKeeper == null)
        {
            Debug.Log("GoalBehavior: Could not find ScoreKeeper object.");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_scoreKeeper == null) return;
        
        _scoreKeeper.Goal(owningPlayerID == 1 ? 2 : 1);
    }
}
