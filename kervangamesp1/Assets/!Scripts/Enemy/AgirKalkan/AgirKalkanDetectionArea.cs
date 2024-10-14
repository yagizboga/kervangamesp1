using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgirKalkanDetectionArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        GameObject.FindGameObjectWithTag("AgirKalkan").GetComponent<AgirKalkan>().DetectionAreaBool = true;
    }
}
