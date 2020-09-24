using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.GetComponent<Player>() != null)
        {
            if(collision.contacts[0].normal.y < 0.5){
                Stone.spawn = true;
            }
        }
    }
}
