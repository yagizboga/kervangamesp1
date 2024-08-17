using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavanTopcusuState : State
{
    protected HavanTopcusu havanTopcusu;

    public HavanTopcusuState(HavanTopcusu havanTopcusu){
        this.havanTopcusu = havanTopcusu;
    }
    public virtual void OnStateEnter(){}
    public virtual void OnStateUpdate(){}
    public virtual void OnStateFixedUpdate(){}
    public virtual void OnStateExit(){}
}
