using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BladeState : MonoBehaviour, State 
{
    protected Blade blade;
    private float timer = 0;
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
