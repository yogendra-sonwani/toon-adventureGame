using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float mspeed = 3.0f;
    public bool inAir = false, dragged = false;
    public float jforce = 25f;
    public int i = 0, enrmyT = 0;
    public char dir = 'r';
    Vector3 characterScale;
    Vector3 playerCpos;
    float characterScaleX;
    public Floor ob;
    public Coins obj;
    public Spikes sobj;
    public static bool draggable = false;
    Vector3 move;
    // Start is called before the first frame update
    void Awake(){
        ob = GameObject.FindObjectOfType<Floor>();
        obj = GameObject.FindObjectOfType<Coins>();
        sobj = GameObject.FindObjectOfType<Spikes>();
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
            if(draggable == true){
                ob.dragg();
            }
            if(GetComponent<SpriteRenderer>().color == Color.yellow){
                GetComponent<SpriteRenderer>().color = Color.white;
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
        if (collision.collider.GetComponent<SwingThrow>() != null)
        {
            playerCpos = transform.position;
            Debug.Log(playerCpos);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("coins")){
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("dragon")){
            Destroy(other.gameObject);
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
        if(draggable == true && dragged = true){
            if(transform.position.y > 34.17 || transform.position.y < 41.89 || transform.position.x > 2.82 || transform.position.x < 14.45){
                string currentScene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentScene);
            }
        }
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
            Destroy(gameObject);
            enrmyT = 0;
        }
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp() {
        if(draggable == true){
            dragged = false;
            Vector2 dirTinit = playerCpos - transform.position;
            GetComponent<Rigidbody2D>().AddForce(dirTinit * 1100);
        }
    }

    private void OnMouseDrag() {
        if(draggable == true)
        {
            dragged = true;
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPos.x, newPos.y);
        }
    }

    public void destroyMe(){
        Destroy(gameObject);
    }
}
