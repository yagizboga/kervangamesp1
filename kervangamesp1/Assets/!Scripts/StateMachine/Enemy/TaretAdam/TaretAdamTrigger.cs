using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretAdamTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Blade") || other.CompareTag("Code")){
            gameObject.transform.parent.GetComponent<TaretAdam>().TriggerEntered = true;
        }
    }
}
