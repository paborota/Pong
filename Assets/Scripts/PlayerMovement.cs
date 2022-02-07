using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    
    [SerializeField] private GameObject topWall;
    [SerializeField] private GameObject bottomWall;
    [SerializeField] private float padding = 0.75f;

    private float _upperClamp;
    private float _lowerClamp;
    
    private float _yVelocity;

    private void Awake()
    {
        if (topWall != null)
        {
            _upperClamp = topWall.transform.position.y - padding;
        }
        if (bottomWall != null)
        {
            _lowerClamp = bottomWall.transform.position.y + padding;
        }
    }

    void Update()
    {
        Move();
    }

    private void OnMove(InputValue value)
    {
        _yVelocity = value.Get<Vector2>().y;
    }

    private void Move()
    {
        var currentPosition = transform.position;
        var currentYPosition = currentPosition.y + _yVelocity * moveSpeed * Time.deltaTime;
        currentYPosition = Mathf.Clamp(currentYPosition, _lowerClamp, _upperClamp);
        transform.position = new Vector3(currentPosition.x, currentYPosition, 0.0f);
    }
}
