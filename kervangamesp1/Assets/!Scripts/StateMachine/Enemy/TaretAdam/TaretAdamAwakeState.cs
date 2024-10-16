using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.XR;

public class TaretAdamAwakeState : TaretAdamState
{
    public TaretAdam TaretAdam;

    public TaretAdamAwakeState(TaretAdam TaretAdam):base(TaretAdam){
        this.TaretAdam = TaretAdam;
    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateUpdate()
    {
    }

    public override void OnStateFixedUpdate(){}

    

    public override void OnStateExit()
    {

    } 

}