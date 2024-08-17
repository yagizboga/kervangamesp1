using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavanTopcusuAwakeState : HavanTopcusuState
{
    public HavanTopcusu Havantopcusu;
    HavanTopcusuShootingState shootingState;
    

    public HavanTopcusuAwakeState(HavanTopcusu Havantopcusu):base(Havantopcusu){
        this.Havantopcusu = Havantopcusu;
    }

    public override void OnStateEnter()
    {
        shootingState = new HavanTopcusuShootingState(havanTopcusu);
    }

    public override void OnStateUpdate()
    {

    }

    public override void OnStateFixedUpdate()
    {
    }

    public override void OnStateExit()
    {

    }
}
