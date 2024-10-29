using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavanTopcusuTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Blade") || other.CompareTag("Code")){
            gameObject.transform.parent.GetComponent<HavanTopcusu>().TriggerArea=true;
        }
        
    }
}
