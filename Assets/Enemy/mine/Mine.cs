using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int health = 100;
    public Player ob;
    void Awake(){
        ob = GameObject.FindObjectOfType<Player>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.GetComponent<Player>() != null)
        {
            ob.destroyMe();
        }
    }
    public void TakeDamage (int damage){
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die(){
        Destroy(gameObject);
    }
}
