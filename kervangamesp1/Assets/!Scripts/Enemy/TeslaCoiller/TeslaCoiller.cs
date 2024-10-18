using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeslaCoiller : Enemy
{
    

    TeslaCoillerAwakeState awakeState;
    public GameObject ElectricPoint;
    public int id;


    void Start(){
        ChangeState(awakeState);
        ElectricPoint = transform.GetChild(0).GameObject();

        
    }
    void Awake(){
        awakeState = new TeslaCoillerAwakeState(this);
    }


}
