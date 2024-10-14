using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberP2LaserState : CyberState
{
    Cyber Cyber;

    CyberP2LaserState(Cyber Cyber):base(Cyber){
        this.Cyber = Cyber;
    }

    public override void OnStateEnter(){}
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
