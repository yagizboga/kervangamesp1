using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;

    void FixedUpdate() 
    {
        currentState.OnStateFixedUpdate();    
    }

    void Update() 
    {
        currentState.OnStateUpdate();    
    }

    public void ChangeState(State newState)
    {
        currentState.OnStateExit();
        currentState = newState;
        currentState.OnStateEnter();
    }
}
