using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgirKalkanState : State
{
    public AgirKalkan agirKalkan;
    AgirKalkanState(AgirKalkan agirKalkan){
        this.agirKalkan = agirKalkan;
    }
    public virtual void OnStateEnter(){}
    public virtual void OnStateUpdate(){}
    public virtual void OnStateFixedUpdate(){}
    public virtual void OnStateExit(){}
}
