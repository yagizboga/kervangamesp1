using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GüvenlikSefiPhase1State : GüvenlikSefiState
{
    GüvenlikSefi GüvenlikSefi;
    private float AttackCoolDown=0f;
    private float TimeSinceAttack=0f;
    private int CurrrentAttackIndex=0;
    public GüvenlikSefiPhase1State(GüvenlikSefi GüvenlikSefi):base(GüvenlikSefi){
        this.GüvenlikSefi = GüvenlikSefi;
    }
    public override void OnStateEnter(){
        Debug.Log("Phase 1");
    }
    public override void OnStateUpdate(){
    }
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
