using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GüvenlikSefiAwakeState : GüvenlikSefiState
{
    GüvenlikSefi GüvenlikSefi;
    public GüvenlikSefiAwakeState(GüvenlikSefi GüvenlikSefi):base(GüvenlikSefi){
        this.GüvenlikSefi = GüvenlikSefi;
    }
    public override void OnStateEnter(){
        Debug.Log("awake");
    }
    public override void OnStateUpdate(){
    }
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
