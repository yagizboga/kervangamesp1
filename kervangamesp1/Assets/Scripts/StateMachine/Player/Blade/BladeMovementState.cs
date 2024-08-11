using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMovementState : State
{
    public Blade blade;
    private float MoveSpeed = 50f;
    Vector3 BladePosition = Vector3.zero;
    

    public BladeMovementState(Blade blade){
        this.blade = blade;
    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateUpdate()
    {

    }

    public override void OnStateFixedUpdate()
    {
        HandleMovement();
    }

    public override void OnStateExit()
    {

    }

    private void HandleMovement(){
        if(Input.GetKey("d")){
            BladePosition.x += MoveSpeed;
            Debug.Log("d");
        }
        if(Input.GetKey("a")){
            BladePosition.x -= MoveSpeed;
            Debug.Log("a");
        }

        blade.transform.position += BladePosition;
    }
}
