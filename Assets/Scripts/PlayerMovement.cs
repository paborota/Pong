using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private float moveSpeed = 100.0f;

    private Rigidbody2D _myRigidody;
    private float _yVelocity;
    private void Awake()
    {
        // Grab rigid body reference.
        _myRigidody = GetComponent<Rigidbody2D>();
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
        var velocityToAdd = new Vector2(0.0f, _yVelocity);
        _myRigidody.velocity = velocityToAdd * moveSpeed * Time.deltaTime;
    }
}
