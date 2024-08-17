using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.XR;

public class TaretAdamAwakeState : TaretAdamState
{
    public TaretAdam TaretAdam;
    TaretAdamShootingState shootingState;

    public TaretAdamAwakeState(TaretAdam TaretAdam):base(TaretAdam){
        this.TaretAdam = TaretAdam;
    }

    public override void OnStateEnter()
    {
        taretAdam.rb.velocity = Vector2.zero;
        shootingState = new TaretAdamShootingState(taretAdam);
    }

    public override void OnStateUpdate()
    {
    }

    public override void OnStateFixedUpdate()
    {
        if(taretAdam.transform.position.y >= taretAdam.RiseHeight){
            taretAdam.rb.velocity = Vector2.zero;
            taretAdam.ChangeState(shootingState);
        }
        }

    

    public override void OnStateExit()
    {

    }

     public void TriggerRise(float RiseSpeed)
    {
        taretAdam.rb.velocity = new Vector2(0, RiseSpeed);
    }

}