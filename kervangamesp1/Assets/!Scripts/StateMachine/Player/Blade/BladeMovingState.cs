using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMovingState : BladeState
{
    
    public BladeMovingState(Blade blade) : base(blade)
    {

    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }

    public override void OnStateFixedUpdate()
    {
        HandleMovement();
    }

    public override void OnStateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            blade.ChangeState(new BladeAttackState(blade));
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            blade.ChangeState(new BladeExecutionState(blade));
        }
    }

    private void HandleMovement()
    {
        blade.CheckGround();
        
        if (blade.isGrounded && Input.GetKey(KeyCode.W))
        {
            blade.verticalShootingDir = VerticalShootingDir.Up;
            blade.ChangeAttackPoint();
            
            blade.rb.velocity = new Vector2(blade.rb.velocity.x, blade.jumpSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            blade.verticalShootingDir = VerticalShootingDir.Normal;
            blade.ChangeAttackPoint();

            blade.rb.velocity = new Vector2(-blade.movementSpeed, blade.rb.velocity.y);
            if (blade.isFacingRight)
            {
                blade.Flip();
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            blade.verticalShootingDir = VerticalShootingDir.Normal;
            blade.ChangeAttackPoint();

            blade.rb.velocity = new Vector2(blade.movementSpeed, blade.rb.velocity.y);
            if (!blade.isFacingRight)
            {
                blade.Flip();
            }
        }

        else if (Input.GetKey(KeyCode.S))
        {
            blade.verticalShootingDir = VerticalShootingDir.Down;
            blade.ChangeAttackPoint();
        }

        else
        {
            blade.rb.velocity = new Vector2(0, blade.rb.velocity.y);
        }
    }
}
