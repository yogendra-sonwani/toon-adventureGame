using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float mspeed = 6.0f;
    public bool inAir = false;
    public float jforce = 25f;
    public int i = 0;
    public int score = 0;
    public int scoreAdded = 10;
    public Floor ob;
    public Coins obj;
    Vector3 move;
    // Start is called before the first frame update
    void Awake(){
        ob = GameObject.FindObjectOfType<Floor>();
        obj = GameObject.FindObjectOfType<Coins>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.GetComponent<Floor>() != null)
        {
            inAir = ob.resetJump(inAir);
            jforce = ob.resetJumpF(jforce);
            i = ob.resetI(i);
        }
        if (collision.collider.GetComponent<Coins>() != null)
        {
            score = score + scoreAdded;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Uplift();
        TurnLeft();
        TurnRight();
        move = new Vector3 (Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * (mspeed);
    }

    void Uplift()
    {
        if (inAir == false){
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                i = i + 1;
                if( i == 2){
                    inAir = true;
                    jforce = 10f;
                    i = 0;
                }
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jforce), ForceMode2D.Impulse);
            }
        }
    }

    void TurnLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            transform.localScale = new Vector3(1.3f, 1.3f, 1.0f);}
    }
    void TurnRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            transform.localScale = new Vector3(-1.3f, 1.3f, 1.0f);}
    }
}
