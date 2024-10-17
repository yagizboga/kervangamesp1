using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KosanAdamAwakeState : KosanAdamState
{
     KosanAdam KosanAdam;
    public KosanAdamAwakeState(KosanAdam KosanAdam):base(KosanAdam){
        this.KosanAdam = KosanAdam;
    }

    public override void OnStateEnter(){
    }
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
