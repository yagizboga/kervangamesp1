using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState;

    void FixedUpdate(){
        CurrentState.OnStateFixedUpdate();
    }

    void Update(){
        CurrentState.OnStateUpdate();
    }

    public void ChangeState(State NewState){
        CurrentState.OnStateExit();
        CurrentState = NewState;
        CurrentState.OnStateEnter();

    }
}
