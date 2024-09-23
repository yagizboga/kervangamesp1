using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaCoillerAwakeState : TeslaCoillerState
{
    TeslaCoiller TeslaCoiller;
    public TeslaCoillerAwakeState(TeslaCoiller TeslaCoiller):base(TeslaCoiller){
        this.TeslaCoiller = TeslaCoiller;
    }
    
    public override void OnStateEnter(){}
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
