using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 50;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        transform.Rotate(0f, 0f, 270f);
    }

    void OnTriggerEnter2D(Collider2D hitinfo) {
        JumpSkull js = hitinfo.GetComponent<JumpSkull>();
        EnemyGun eg = hitinfo.GetComponent<EnemyGun>();
        Mine m = hitinfo.GetComponent<Mine>();
        if(m != null){
            eg.TakeDamage(100);
            Destroy(gameObject);
        }
        if(eg != null){
            eg.TakeDamage(50);
            Destroy(gameObject);
        }
        if(js != null){
            js.TakeDamage(34);
            Destroy(gameObject);
        }
    }
}
