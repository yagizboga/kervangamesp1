using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretAdamTrigger : MonoBehaviour
{
    TaretAdam taretAdamscript;

    void Start(){
        taretAdamscript = GetComponentInParent<TaretAdam>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Blade") || other.CompareTag("Code")){
            taretAdamscript.TriggerEntered = true;
        }
    }
}
