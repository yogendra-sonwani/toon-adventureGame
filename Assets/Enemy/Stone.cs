using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Player ob;
    private Rigidbody2D rb;
    public static bool spawn = false;
    void Awake(){
        ob = GameObject.FindObjectOfType<Player>();
    }
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.GetComponent<Player>() != null)
        {
            ob.destroyMe();
        }
    }
    void Update(){
        if(spawn == true)
        {
            rb.gravityScale = 4;
        }
    }
}
