using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeslaCoiller : StateMachine
{
    public float Health = 100f;
    TeslaCoillerAwakeState awakeState;
    public GameObject ElectricPoint;
    void Start(){
        ChangeState(awakeState);
        ElectricPoint = transform.GetChild(0).GameObject();
        
    }
    void Awake(){
        awakeState = new TeslaCoillerAwakeState(this);
    }


}
