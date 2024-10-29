using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavanTopcusuState : EnemyState
{
    protected HavanTopcusu havanTopcusu;

    public HavanTopcusuState(HavanTopcusu havanTopcusu){
        this.havanTopcusu = havanTopcusu;
    }
    public override void OnStateEnter(){}
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
