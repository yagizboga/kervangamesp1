using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretAdamAwakeState : State
{
    private StateMachine stateMachine;
    public TaretAdamAwakeState(StateMachine statemachine){
        this.stateMachine = statemachine;
    }
    public void OnStateEnter(){}
    public void OnStateUpdate(){}
    public void OnStateFixedUpdate(){}
    public void OnStateExit(){}
}
