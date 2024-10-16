using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HavanTopcusuBullet : MonoBehaviour
{
    GameObject Blade;
    GameObject Code;
    Rigidbody2D rb;
    float Speed = 5f;
    float UpwardSpeed = 2f;
    public bool bladebool = true;
    void Start(){
        Blade = GameObject.FindGameObjectWithTag("Blade");
        Code = GameObject.FindGameObjectWithTag("Code");
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    void FixedUpdate(){
        if(bladebool){
            TrackBlade();
        }
        else if(!bladebool){
            TrackCode();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Blade") || other.CompareTag("Ground") || other.CompareTag("Code"))
        {
            Destroy(gameObject);
        }
    }

    public void TrackBlade(){
        Vector3 Direction = (Blade.transform.position - transform.position).normalized;
        transform.position += Direction * Time.deltaTime * Speed;
        transform.position+= new Vector3(0,UpwardSpeed,0) * Time.deltaTime;
        if(UpwardSpeed <=0){
            UpwardSpeed-=Time.deltaTime;
        }
    }

    public void TrackCode(){
        Vector3 Direction = (Code.transform.position - transform.position).normalized;
        transform.position += Direction * Time.deltaTime * Speed;
        transform.position+= new Vector3(0,UpwardSpeed,0) * Time.deltaTime;
        if(UpwardSpeed <=0){
            UpwardSpeed-=Time.deltaTime;
        }
    }


}
