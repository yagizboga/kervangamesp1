using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TaretAdamAwakeState : TaretAdamState
{
    public TaretAdam TaretAdam;
    bool isTrigger = false;

    public TaretAdamAwakeState(TaretAdam TaretAdam):base(TaretAdam){
        this.TaretAdam = TaretAdam;
    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateUpdate()
    {
        if(isTrigger == true){
            TaretAdam.rb.velocity = new Vector2(0,TaretAdam.RiseSpeed);
        }
        if(TaretAdam.transform.position.y == TaretAdam.RiseHeight){
            TaretAdam.rb.velocity = Vector2.zero;
        }
    }

    public override void OnStateFixedUpdate()
    {

    }

    public override void OnStateExit()
    {

    }

}
