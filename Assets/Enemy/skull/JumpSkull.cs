using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSkull : MonoBehaviour
{
    public float ms = 0.5f;
    public bool mr;
    public bool jskull = false;
    public Player ob;
    void Awake(){
        ob = GameObject.FindObjectOfType<Player>();
    }
    void Update()
    {
        if(mr){
            transform.Translate(2 * Time.deltaTime * ms, 0f, 0f);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else{
            transform.Translate(-2 * Time.deltaTime * ms, 0f, 0f);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if(!jskull){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 15f), ForceMode2D.Impulse);
            jskull = true;
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
        if (collision.collider.GetComponent<Floor>() != null){
            jskull = false;
        }
    }
}
