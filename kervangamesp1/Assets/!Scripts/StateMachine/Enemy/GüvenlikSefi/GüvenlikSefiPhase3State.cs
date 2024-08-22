using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GüvenlikSefiPhase3State : GüvenlikSefiState
{
    GüvenlikSefi GüvenlikSefi;
    public GüvenlikSefiPhase3State(GüvenlikSefi GüvenlikSefi):base(GüvenlikSefi){
        this.GüvenlikSefi = GüvenlikSefi;
    }
    public override void OnStateEnter(){
        Debug.Log("Phase 3");
    }
    public override void OnStateUpdate(){
    }
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}