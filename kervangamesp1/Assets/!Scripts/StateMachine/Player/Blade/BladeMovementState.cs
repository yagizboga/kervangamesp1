using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMovementState : BladeState
{
    public Blade blade;
    private float MoveSpeed = 1f;
    Vector3 BladePosition = Vector3.zero;
    

    public BladeMovementState(Blade blade):base(blade){
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
        }
        if(Input.GetKey("a")){
            BladePosition.x -= MoveSpeed;
        }

        blade.transform.position += BladePosition*Time.deltaTime;
    }
}
