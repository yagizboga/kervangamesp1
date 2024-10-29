using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgirKalkanDetectionArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Blade") || other.CompareTag("Code")){
            transform.parent.gameObject.GetComponent<AgirKalkan>().DetectionAreaBool = true;
        }
        
    }
}
