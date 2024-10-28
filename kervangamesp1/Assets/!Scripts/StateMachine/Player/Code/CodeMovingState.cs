using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeMovingState : CodeState
{
    public CodeMovingState(Code code) : base(code)
    {

    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateExit()
    {
        code.animator.SetBool("isCodeRunning", false);
        code.animator.SetBool("isCodeJump", false);
    }

    public override void OnStateFixedUpdate()
    {
    }

    public override void OnStateUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (!(Input.GetKey(code.jumpKey) || Input.GetKey(code.moveLeftKey) || Input.GetKey(code.crouchKey) || Input.GetKey(code.moveRightKey)))
        {
            code.ChangeState(new CodeIdleState(code));
        }

        code.CheckGround();

        if (code.isGrounded && Input.GetKey(code.jumpKey))
        {
            code.animator.SetBool("isCodeJump", true);

            code.verticalShootingDir = VerticalShootingDir.Up;
            code.ChangeFirePosition();

            code.rb.velocity = new Vector2(code.rb.velocity.x, code.jumpSpeed);
        }

        if (Input.GetKey(code.moveLeftKey))
        {
            code.animator.SetBool("isCodeRunning", true);
            code.verticalShootingDir = VerticalShootingDir.Normal;
            code.ChangeFirePosition();
            code.rb.velocity = new Vector2(-code.movementSpeed, code.rb.velocity.y);
            if (code.isFacingRight)
            {
                code.spriteRenderer.flipX = true;
                code.Flip();
            }
        }

        else if (Input.GetKey(code.moveRightKey))
        {
            code.animator.SetBool("isCodeRunning", true);
            code.verticalShootingDir = VerticalShootingDir.Normal;
            code.ChangeFirePosition();
            code.rb.velocity = new Vector2(code.movementSpeed, code.rb.velocity.y);
            if (!code.isFacingRight)
            {
                code.spriteRenderer.flipX = false;
                code.Flip();
            }
        }

        else if(Input.GetKey(code.crouchKey))
        {
            code.verticalShootingDir = VerticalShootingDir.Down;
            code.ChangeFirePosition();
        }

        else
        {
            code.rb.velocity = new Vector2(0, code.rb.velocity.y);
        }
    }
}
