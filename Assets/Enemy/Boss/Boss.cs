using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 100;
    public float ms = 1.0f;
    public bool mr;
    public wallDoor wd;
    // Start is called before the first frame update
    void Awake(){
        wd = GameObject.FindObjectOfType<wallDoor>();
    }
    // public GameObject deathEffect;
    void Update()
    {
        if(mr){
            transform.Translate(2 * Time.deltaTime * ms, 0f, 0f);
            transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);
        }
        else{
            transform.Translate(-2 * Time.deltaTime * ms, 0f, 0f);
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("turn")){
            if(mr == false){
                mr = true;
            }
            else{
                mr = false;
            }
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
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        wd.DestroyWall();
        Destroy(gameObject);
    }
}
