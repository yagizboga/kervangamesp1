using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GüvenlikSefiDeathState : GüvenlikSefiState
{
    GüvenlikSefi GüvenlikSefi;
    public GüvenlikSefiDeathState(GüvenlikSefi GüvenlikSefi):base(GüvenlikSefi){
        this.GüvenlikSefi = GüvenlikSefi;
    }
    public override void OnStateEnter(){
        Debug.Log("Death");
    }
    public override void OnStateUpdate(){
    }
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
