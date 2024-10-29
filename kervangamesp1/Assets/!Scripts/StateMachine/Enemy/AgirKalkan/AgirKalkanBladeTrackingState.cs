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
        agirKalkan.GetComponent<Animator>().SetBool("TriggerAreaBool",true);
    }
    public override void OnStateUpdate(){
        
    }
    public override void OnStateFixedUpdate(){
        Direction = (BladeTransform.position - agirKalkan.transform.Find("Body").transform.position).normalized;
        if(agirKalkan.transform.Find("Body").transform.position.x - BladeTransform.position.x >2f){
            agirKalkan.transform.position += new Vector3(Direction.x,0,0) * agirKalkan.agirKalkanSpeed * Time.deltaTime;
        }
        
        
    }
    public override void OnStateExit(){}
}
