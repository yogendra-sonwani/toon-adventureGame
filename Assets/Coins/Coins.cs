using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    // public AudioSource collectSound;
    private void OnTriggerEnter2D(Collider2D other) {
        // collectSound.Play();
        ScoreManager.scorec += 2;
        Destroy(gameObject);
    }
}
