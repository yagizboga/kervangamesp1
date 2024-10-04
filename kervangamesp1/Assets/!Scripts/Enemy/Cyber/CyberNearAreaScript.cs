using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CyberNearAreaScript : MonoBehaviour
{
    
    GameObject cyber;
    Cyber cyberscript;
    void Start(){
        cyber = GameObject.FindGameObjectWithTag("Cyber");
        cyberscript = cyber.GetComponent<Cyber>();
    }
    void OnTriggerEnter2D(Collider2D other){

        if(cyber != null && cyberscript !=null){
            if(other.CompareTag("Blade") && cyberscript.CyberNearAreaBool == false){
            cyberscript.CyberNearAreaBool = true;
            Debug.Log("blade");
        }
        else if(other.CompareTag("Code")){
            cyberscript.CyberNearAreaBool = true;
            Debug.Log("code");
        }
        }
        
    }
}
