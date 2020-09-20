using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float mspeed = 3.0f;
    public bool inAir = false;
    public float jforce = 25f;
    public int i = 0, enrmyT = 0;
    public char dir = 'r';
    Vector3 characterScale;
    float characterScaleX;
    public Floor ob;
    public Coins obj;
    public Spikes sobj;
    public ScoreManager sm;
    public static bool skills = false;
    Vector3 move;
    // Start is called before the first frame update
    void Awake(){
        ob = GameObject.FindObjectOfType<Floor>();
        obj = GameObject.FindObjectOfType<Coins>();
        sobj = GameObject.FindObjectOfType<Spikes>();
        sm = GameObject.FindObjectOfType<ScoreManager>();
    }

    void Start() {
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.GetComponent<Floor>() != null)
        {
            if(collision.contacts[0].normal.y > -0.5){
                inAir = ob.resetJump(inAir);
                jforce = ob.resetJumpF(jforce);
                i = ob.resetI(i);
            }
        }
        if (collision.collider.GetComponent<Boss>() != null)
        {
            if(collision.contacts[0].normal.y > -0.5){
                inAir = false;
                jforce = 25.0f;
                i = 0;
            }
        }
        if (collision.collider.GetComponent<Spikes>() != null)
        {
            halfhealth();
            if(collision.contacts[0].normal.y > -0.5){
                inAir = sobj.resetJump(inAir);
                jforce = sobj.resetJumpF(jforce);
                i = sobj.resetI(i);
            }
        }
        if (collision.collider.GetComponent<Boss>() != null)
        {
            halfhealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("coins")){
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("bullet")){
            Destroy(other.gameObject);
            skills =true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Uplift();
        move = new Vector3 (Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * (mspeed);
        transform.Translate(Input.GetAxis("Horizontal") * mspeed * Time.deltaTime, 0f, 0f);

        // character flip
        if(Input.GetAxis("Horizontal") < 0) {
            characterScale.x = -characterScaleX;
        }
        if(Input.GetAxis("Horizontal") > 0) {
            characterScale.x = characterScaleX;
        }
        transform.localScale = characterScale;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,-20.9f,25.4f),
            Mathf.Clamp(transform.position.y,-5f,1000f)
        );
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

    void halfhealth()
    {
        enrmyT += 1;
        if(enrmyT == 2)
        {
            enrmyT = 0;
            skills = false;
            sm.ResetS();
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void destroyMe(){
        enrmyT = 0;
        skills = false;
        sm.ResetS();
        Destroy(gameObject);
        SceneManager.LoadScene(2);
    }
}
