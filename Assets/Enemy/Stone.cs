using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
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
}
