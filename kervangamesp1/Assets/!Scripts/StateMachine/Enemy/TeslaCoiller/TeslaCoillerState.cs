using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaCoillerState : State
{
    protected TeslaCoiller teslaCoiller;

    public TeslaCoillerState(TeslaCoiller teslaCoiller){
        this.teslaCoiller = teslaCoiller;
    }
    public virtual void OnStateEnter(){}
    public virtual void OnStateUpdate(){}
    public virtual void OnStateFixedUpdate(){}
    public virtual void OnStateExit(){}
}
