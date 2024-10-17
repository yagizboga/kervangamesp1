using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KosanAdamState : State
{
        protected KosanAdam KosanAdam;

    public KosanAdamState(KosanAdam KosanAdam){
        this.KosanAdam = KosanAdam;
    }
    public virtual void OnStateEnter(){}
    public virtual void OnStateUpdate(){}
    public virtual void OnStateFixedUpdate(){}
    public virtual void OnStateExit(){}
}
