﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    // public AudioSource collectSound;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("player")){
            // collectSound.Play();
            ScoreManager.scorec += 1;
            Destroy(gameObject);
        }
    }
}
