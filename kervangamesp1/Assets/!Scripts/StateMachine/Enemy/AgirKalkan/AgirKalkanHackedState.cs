using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgirKalkanHackedState : AgirKalkanState
{
    public AgirKalkan AgirKalkan;
    public AgirKalkanHackedState(AgirKalkan AgirKalkan):base(AgirKalkan){
        this.AgirKalkan = AgirKalkan;
    }
    public override void OnStateEnter(){}
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
