using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeState : State
{
    protected Blade Blade;

    public BladeState(Blade Blade){
        this.Blade = Blade;
    }
    public virtual void OnStateEnter(){}
    public virtual void OnStateUpdate(){}
    public virtual void OnStateFixedUpdate(){}
    public virtual void OnStateExit(){}
}
