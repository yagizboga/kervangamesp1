using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretAdamState : State
{
    protected TaretAdam taretAdam;

    public TaretAdamState(TaretAdam taretAdam){
        this.taretAdam = taretAdam;
    }
    public virtual void OnStateEnter(){}
    public virtual void OnStateUpdate(){}
    public virtual void OnStateFixedUpdate(){}
    public virtual void OnStateExit(){}
}
