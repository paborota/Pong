using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip racketHit;
    [SerializeField] private AudioClip wallHit;

    public void PlayRacketHit()
    {
        if (racketHit == null)
        {
            Debug.Log("SoundManager: racketHit has not been set up.");
        }
        PlayClip(ref racketHit);
    }

    public void PlayWallHit()
    {
        if (wallHit == null)
        {
            Debug.Log("SoundManager: wallHit has not been set up.");
        }
        PlayClip(ref wallHit);
    }

    private void PlayClip(ref AudioClip clip)
    {
        if (Camera.main == null) return;
        
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }
}
