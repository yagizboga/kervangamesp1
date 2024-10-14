using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgirKalkanBladeTrackingState : AgirKalkanState
{
    public AgirKalkan AgirKalkan;
    Vector3 Direction;
    public AgirKalkanBladeTrackingState(AgirKalkan AgirKalkan):base(AgirKalkan){
        this.AgirKalkan = AgirKalkan;
    }
    Transform BladeTransform;
    public override void OnStateEnter(){
        BladeTransform = GameObject.FindGameObjectWithTag("Blade").transform;
    }
    public override void OnStateUpdate(){
        Direction = (BladeTransform.position - agirKalkan.transform.position).normalized;
    }
    public override void OnStateFixedUpdate(){
       // if(agirKalkan.transform.position != BladeTransform.position + new Vector3(2,0,0) && agirKalkan.transform.position != BladeTransform.position - new Vector3(2,0,0)){
        //    agirKalkan.transform.position += new Vector3(Direction.x,Direction.y,0) * agirKalkan.agirKalkanSpeed * Time.deltaTime;
       // }
        agirKalkan.transform.position += new Vector3(Direction.x,Direction.y,0) * agirKalkan.agirKalkanSpeed * Time.deltaTime;
        
    }
    public override void OnStateExit(){}
}
