using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberAwakeState : CyberState
{
    Cyber Cyber;

    public CyberAwakeState(Cyber Cyber):base(Cyber){
        this.Cyber = Cyber;
    }
    public override void OnStateEnter(){
    }
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
