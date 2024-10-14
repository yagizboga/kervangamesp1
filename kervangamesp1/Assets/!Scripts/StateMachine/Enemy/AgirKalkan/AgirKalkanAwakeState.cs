using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgirKalkanAwakeState : AgirKalkanState
{
    public AgirKalkan AgirKalkan;
    public AgirKalkanAwakeState(AgirKalkan AgirKalkan):base(AgirKalkan){
        this.AgirKalkan = AgirKalkan;
    }
    public override void OnStateEnter(){}
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
