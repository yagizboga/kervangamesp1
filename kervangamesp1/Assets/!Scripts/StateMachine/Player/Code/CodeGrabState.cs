using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeGrabState : CodeState
{
    public CodeGrabState(Code code) : base(code)
    {

    }

    public override void OnStateEnter()
    {
        code.animator.SetBool("iscodeGrab", true);
        code.rb.gravityScale = 0;
    }

    public override void OnStateExit()
    {
        code.animator.SetBool("iscodeGrab", false);
        CodeGrabManager.Instance.isCodeRelease = true;
        code.rb.gravityScale = 1.75f;
    }

    public override void OnStateFixedUpdate()
    {

    }

    public override void OnStateUpdate()
    {
        if (!CodeGrabManager.Instance.isCodeGrab) code.ChangeState(new CodeIdleState(code));
        
        HandleGrabMovement();
    }

    private void HandleGrabMovement()
    {
        if (Input.GetKey(code.jumpKey) || Input.GetKey(code.crouchKey))
        {
            code.ChangeState(new CodeIdleState(code));
        }

        else if (Input.GetKey(code.moveLeftKey))
        {
            code.rb.velocity = new Vector2(-code.movementSpeed, 0);
                        
            if (code.isFacingRight)
            {
                code.spriteRenderer.flipX = true;
                code.Flip();
            }
        }

        else if (Input.GetKey(code.moveRightKey))
        {
            code.rb.velocity = new Vector2(code.movementSpeed, 0);

            if (!code.isFacingRight)
            {
                code.spriteRenderer.flipX = false;
                code.Flip();
            }
        }

        else
        {
            code.rb.velocity = Vector2.zero;
        }



    }
}
