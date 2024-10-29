using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HavanTopcusuDeathState : HavanTopcusuState
{
    public HavanTopcusu HavanTopcusu;
    public HavanTopcusuDeathState(HavanTopcusu Havantopcusu):base(Havantopcusu){
    }
    
    public override void OnStateEnter(){
        havanTopcusu.gameObject.GetComponent<Animator>().Play("Base Layer.DeathState");
    }
    public override void OnStateUpdate(){
        if(AnimationIsPlaying()){
            GameObject.Destroy(havanTopcusu);
        }
    }
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}

    bool AnimationIsPlaying(){
        return havanTopcusu.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length > havanTopcusu.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
