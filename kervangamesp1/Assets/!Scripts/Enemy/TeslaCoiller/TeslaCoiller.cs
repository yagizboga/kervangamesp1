using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeslaCoiller : StateMachine
{
    public float Health = 100f;
    TeslaCoillerAwakeState awakeState;
    public BoxCollider2D electricityCollider;
    void Start(){
        ChangeState(awakeState);
        electricityCollider.enabled = false;
        
    }
    void Awake(){
        awakeState = new TeslaCoillerAwakeState(this);
        electricityCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Blade")||other.CompareTag("Code"))
        Debug.Log("Electric");
    }


}
