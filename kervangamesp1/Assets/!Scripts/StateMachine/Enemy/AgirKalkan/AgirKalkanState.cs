using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgirKalkanState : State
{
    protected AgirKalkan agirKalkan;
    public AgirKalkanState(AgirKalkan agirKalkan){
        this.agirKalkan = agirKalkan;
    }
    public virtual void OnStateEnter(){}
    public virtual void OnStateUpdate(){}
    public virtual void OnStateFixedUpdate(){}
    public virtual void OnStateExit(){}
}
