using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretAdamTrigger : MonoBehaviour
{
    public GameObject Turret;
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Blade") || other.CompareTag("Code")){
            Turret.GetComponent<TaretAdam>().TriggerEntered = true;
        }
    }
}
