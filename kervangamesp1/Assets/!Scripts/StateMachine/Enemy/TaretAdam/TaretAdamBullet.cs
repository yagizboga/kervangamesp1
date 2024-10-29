using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretAdamBullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 BulletSpeed;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        BulletSpeed = new Vector2(-10,0);
        rb.velocity = BulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Blade") || other.CompareTag("Code")){
            Debug.Log("Shoot!");
            if(other.CompareTag("Blade")){
                other.GetComponent<Blade>().TakeDamage(5);
            }
            if(other.CompareTag("Code")){
                other.GetComponent<Code>().TakeDamage(5);
            }
            Destroy(gameObject);
        }
    }
}
