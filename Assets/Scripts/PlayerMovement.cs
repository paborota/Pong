using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private float moveSpeed = 5.0f;
    
    private float _yVelocity;

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
        var movementToAdd = new Vector2(0.0f, _yVelocity);
        transform.position += (Vector3)(movementToAdd * moveSpeed * Time.deltaTime);
    }
}
