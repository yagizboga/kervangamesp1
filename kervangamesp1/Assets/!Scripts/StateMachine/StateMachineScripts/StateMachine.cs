using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State CurrentState;

    public void ChangeState(State NewState){
        if(CurrentState != null){
            CurrentState.OnStateExit();
        }
        CurrentState = NewState;
        CurrentState.OnStateEnter();
    }

    private  void Update(){
        if(CurrentState!=null){
            CurrentState.OnStateUpdate();
        }
    }

    private  void FixedUpdate(){
        if(CurrentState!=null){
            CurrentState.OnStateFixedUpdate();
        }
    }
}
