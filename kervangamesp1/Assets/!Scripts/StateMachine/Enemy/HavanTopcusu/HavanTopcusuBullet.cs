using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HavanTopcusuBullet : MonoBehaviour
{
    GameObject Blade;
    GameObject Code;
    Rigidbody2D rb;
    void Start(){
        Blade = GameObject.FindGameObjectWithTag("Blade");
        Code = GameObject.FindGameObjectWithTag("Code");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0,10),ForceMode2D.Impulse);
        
    }

    void FixedUpdate(){
        Vector2 Direction = (Blade.transform.position - transform.position).normalized;
        rb.AddForce(Direction*15);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Blade") || other.CompareTag("Ground") || other.CompareTag("Code"))
        {
            Destroy(gameObject);
        }
    }


}
