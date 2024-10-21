using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeslaCoiller : Enemy
{
    

    TeslaCoillerAwakeState awakeState;
    public GameObject ElectricPoint;


    void Start(){
        ChangeState(awakeState);


        
    }
    void Awake(){
        awakeState = new TeslaCoillerAwakeState(this);
    }


}
