using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManScript : MonoBehaviour
{
    public float ms = 1.0f;
    public bool mr;
    public Player ob;
    void Awake(){
        ob = GameObject.FindObjectOfType<Player>();
    }
    void Update()
    {
        if(mr){
            transform.Translate(2 * Time.deltaTime * ms, 0f, 0f);
            transform.localScale = new Vector3(-0.202123f, 0.2123523f, 1.0f);
        }
        else{
            transform.Translate(-2 * Time.deltaTime * ms, 0f, 0f);
            transform.localScale = new Vector3(0.202123f, 0.2123523f, 1.0f);
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
