using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretAdamBullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 BulletSpeed;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        BulletSpeed = new Vector2(-20,0);
        rb.velocity = BulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Blade") || other.CompareTag("Code")){
            Debug.Log("Shoot!");
        }
    }
}
