using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Blade : StateMachine
{
    private StateMachine stateMachine;
    private BladeMovementState movementState;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        movementState = GetComponent<BladeMovementState>();
        stateMachine.ChangeState(movementState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
