using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float timeBeforeBallMoves = 0.5f;
    [SerializeField] private float startingVelocity = 5.0f;
    [SerializeField] private float speedUpOnPlayerHit = 2.0f;

    private Rigidbody2D _myRigidbody;
    private LayerMask _playerLayer;

    private GameObject _recentlyHitPlayer;
    private SoundManager _soundManager;
    
    private void Awake()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
        _playerLayer = LayerMask.GetMask("Player");
        _soundManager = FindObjectOfType<SoundManager>();
    }

    private void Start()
    {
        Physics.IgnoreLayerCollision(6, 8);
        
        StartCoroutine(StartMovement());
    }

    private IEnumerator StartMovement()
    {
        yield return new WaitForSecondsRealtime(timeBeforeBallMoves);
        _myRigidbody.velocity = Vector2.left * startingVelocity + Vector2.up * Random.Range(-0.5f, 0.5f);
    }

    private void OnPlayerCollision(ref Collision2D col)
    {
        // Only time this will be called is when the ball hits the player
        // so we should also increase speed.
        var myVelocity = _myRigidbody.velocity;
        var horizontalVelocityMultiplier = -1.0f * speedUpOnPlayerHit;
        
        var yOffsetToPlayer = transform.position.y - col.transform.position.y;
        var verticalVelocity = (float)Math.Pow(yOffsetToPlayer, 3.0f) + yOffsetToPlayer;

        var horizontalVelocity = myVelocity.x * horizontalVelocityMultiplier;
        _myRigidbody.velocity = new Vector2(horizontalVelocity, verticalVelocity);

        if (_soundManager == null) return;
        _soundManager.PlayRacketHit();
    }

    private void OnWallCollision()
    {
        _myRigidbody.velocity *= new Vector2(1.0f, -1.0f);
        if (_soundManager == null) return;
        _soundManager.PlayWallHit();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (((1 << col.gameObject.layer) & _playerLayer) != 0)
        {
            if (_recentlyHitPlayer == col.gameObject) return;
            _recentlyHitPlayer = col.gameObject;
            // col object is player, change X
            Debug.Log("Collided with player.");
            OnPlayerCollision(ref col);
        }
        else
        {
            // col object not player, change Y
            Debug.Log("Collided with wall.");
            OnWallCollision();
        }
    }
}
