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
        blade.animator.SetBool("isBladeRunning", false);
        blade.animator.SetBool("isBladeJump", false);
    }

    public override void OnStateFixedUpdate()
    {
        HandleMovement();
    }

    public override void OnStateUpdate()
    {

    }
    
    private void HandleMovement()
    {
        if (!(Input.GetKey(blade.jumpKey) || Input.GetKey(blade.moveLeftKey) || Input.GetKey(blade.crouchKey) || Input.GetKey(blade.moveRightKey)))
        {
            blade.ChangeState(new BladeIdleState(blade));
        }

        blade.CheckGround();
        
        if (blade.isGrounded && Input.GetKey(blade.jumpKey))
        {
            blade.animator.SetBool("isBladeJump", true);

            blade.verticalShootingDir = VerticalShootingDir.Up;
            blade.ChangeAttackPoint();
            
            blade.rb.velocity = new Vector2(blade.rb.velocity.x, blade.jumpSpeed);
        }

        if (Input.GetKey(blade.moveLeftKey))
        {
            blade.animator.SetBool("isBladeRunning", true);

            blade.verticalShootingDir = VerticalShootingDir.Normal;
            blade.ChangeAttackPoint();

            blade.rb.velocity = new Vector2(-blade.movementSpeed, blade.rb.velocity.y);
            if (blade.isFacingRight)
            {
                blade.spriteRenderer.flipX = true;
                blade.Flip();
            }
        }

        else if (Input.GetKey(blade.moveRightKey))
        {
            blade.animator.SetBool("isBladeRunning", true);

            blade.verticalShootingDir = VerticalShootingDir.Normal;
            blade.ChangeAttackPoint();

            blade.rb.velocity = new Vector2(blade.movementSpeed, blade.rb.velocity.y);
            if (!blade.isFacingRight)
            {
                blade.spriteRenderer.flipX = false;
                blade.Flip();
            }
        }

        else if (Input.GetKey(blade.crouchKey))
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