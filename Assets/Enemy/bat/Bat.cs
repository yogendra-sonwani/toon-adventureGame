using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public Player ob;
    void Awake(){
        ob = GameObject.FindObjectOfType<Player>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.GetComponent<Player>() != null)
        {
            if(!(collision.contacts[0].normal.y > -0.5)){
                Destroy(gameObject);
            }
            else{
                ob.destroyMe();
            }
        }
    }
}
