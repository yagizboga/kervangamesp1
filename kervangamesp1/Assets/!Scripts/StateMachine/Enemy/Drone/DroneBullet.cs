using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DroneBullet : MonoBehaviour
{

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Blade") || other.CompareTag("Code")){
            Destroy(gameObject);
        }
        
    }
}
