using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TaretAdamTriggerState : TaretAdamState
{
    TaretAdam TaretAdam;
    Vector3 enterpos;
    public TaretAdamTriggerState(TaretAdam TaretAdam):base(TaretAdam){
        this.TaretAdam = TaretAdam;
    }

    public override void OnStateEnter(){
        enterpos = taretAdam.transform.position;
    }
    public override void OnStateUpdate(){

    }
    public override void OnStateFixedUpdate(){
        if((taretAdam.transform.position.y - enterpos.y) <= 1.5f){
            taretAdam.transform.position += new Vector3(0,Time.deltaTime*taretAdam.RiseSpeed,0);
        }
        else{
            taretAdam.ChangeState(taretAdam.shootingState);
        }
    }
    public override void OnStateExit(){}
}
