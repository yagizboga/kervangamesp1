using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeState : State
{
    protected Blade blade;
    public BladeState(Blade blade)
    {
        this.blade = blade;
    }

    public virtual void OnStateEnter()
    {

    }

    public virtual void OnStateExit()
    {

    }

    public virtual void OnStateFixedUpdate()
    {

    }

    public virtual void OnStateUpdate()
    {
        
    }
}
