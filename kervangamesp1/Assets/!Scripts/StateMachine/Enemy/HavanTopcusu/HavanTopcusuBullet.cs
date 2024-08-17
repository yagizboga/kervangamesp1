using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HavanTopcusuBullet : MonoBehaviour
{
    GameObject Blade;
    Rigidbody2D rb;
    void Start(){
        Blade = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0,10),ForceMode2D.Impulse);
        
    }

    void FixedUpdate(){
        Vector2 Direction = (Blade.transform.position - transform.position).normalized;
        rb.AddForce(Direction*15);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }


}
