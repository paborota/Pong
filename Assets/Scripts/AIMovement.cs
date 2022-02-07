using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private GameObject ball;
    
    [SerializeField] private float yOffsetLimit = 1.0f;

    private Rigidbody2D _myRigidbody;

    private void Awake()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (ball == null || _myRigidbody == null) return;
        
        var currentPosition = transform.position;
        var currentYPosition = currentPosition.y;
        var yOffset = ball.transform.position.y - currentYPosition;

        var newVelocity = Vector2.zero;
        if (Mathf.Abs(yOffset) > yOffsetLimit)
        {
            newVelocity = new Vector2(0.0f, moveSpeed * Mathf.Sign(yOffset));
        }

        _myRigidbody.velocity = newVelocity;
    }
    
    
    //
    // [SerializeField] private float padding = 0.75f;
    // [SerializeField] private GameObject topWall;
    // [SerializeField] private GameObject bottomWall;
    //
    // private float _upperClamp;
    // private float _lowerClamp;

    // private void Awake()
    // {
    //     if (topWall != null)
    //     {
    //         _upperClamp = topWall.transform.position.y - padding;
    //     }
    //     if (bottomWall != null)
    //     {
    //         _lowerClamp = bottomWall.transform.position.y - padding;
    //     }
    // }

    // private void Update()
    // {
    //     if (ball == null) return;
    //
    //     var currentPosition = transform.position;
    //     var currentYPosition = currentPosition.y;
    //     var yOffset = ball.transform.position.y - currentYPosition;
    //     
    //     if (Mathf.Abs(yOffset) < yOffsetLimit) return;
    //     currentYPosition += moveSpeed * Time.deltaTime * Math.Sign(yOffset);
    //     currentYPosition = Mathf.Clamp(currentYPosition, _lowerClamp, _upperClamp);
    //     transform.position = new Vector3(currentPosition.x, currentYPosition, 0.0f);
    // }
}
