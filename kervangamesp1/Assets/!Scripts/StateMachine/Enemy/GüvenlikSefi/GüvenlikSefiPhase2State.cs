using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GüvenlikSefiPhase2State : GüvenlikSefiState
{
    GüvenlikSefi GüvenlikSefi;
    public GüvenlikSefiPhase2State(GüvenlikSefi GüvenlikSefi):base(GüvenlikSefi){
        this.GüvenlikSefi = GüvenlikSefi;
    }
    public override void OnStateEnter(){
        Debug.Log("Phase 2");
    }
    public override void OnStateUpdate(){
    }
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
