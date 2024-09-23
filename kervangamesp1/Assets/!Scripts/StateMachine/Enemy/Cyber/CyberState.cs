using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberState : State
{
    protected Cyber cyber;

    public CyberState(Cyber cyber){
        this.cyber = cyber;
    }
    public virtual void OnStateEnter(){}
    public virtual void OnStateUpdate(){}
    public virtual void OnStateFixedUpdate(){}
    public virtual void OnStateExit(){}
}
