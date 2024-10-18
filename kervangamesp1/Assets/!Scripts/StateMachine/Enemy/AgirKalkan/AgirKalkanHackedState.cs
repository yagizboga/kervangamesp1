using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgirKalkanHackedState : AgirKalkanState
{
    public AgirKalkan AgirKalkan;
    
    public AgirKalkanHackedState(AgirKalkan AgirKalkan):base(AgirKalkan){
        this.AgirKalkan = AgirKalkan;
    }
    public override void OnStateEnter(){
        agirKalkan.Bluelight.GetComponent<SpriteRenderer>().enabled = true;
    }
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
