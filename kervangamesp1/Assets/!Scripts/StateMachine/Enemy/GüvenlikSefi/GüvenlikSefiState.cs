using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GüvenlikSefiState : State
{
    protected GüvenlikSefi güvenlikSefi;
    public GüvenlikSefiState(GüvenlikSefi güvenlikSefi){
        this.güvenlikSefi = güvenlikSefi;
    }
    public virtual void OnStateEnter(){}
    public virtual void OnStateUpdate(){}
    public virtual void OnStateFixedUpdate(){}
    public virtual void OnStateExit(){}
}
