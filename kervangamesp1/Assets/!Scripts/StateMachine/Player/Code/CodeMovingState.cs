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

    }

    public override void OnStateFixedUpdate()
    {
        HandleMovement();
    }

    public override void OnStateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            code.ChangeState(new CodeShootingState(code));           
        }
        if (code._isHackable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                code.ChangeState(new CodeHackState(code));
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                code.ChangeState(new CodeDeactivateBarrierState(code));
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                code.ChangeState(new CodeStunState(code));
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                code._virtualCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
                code._virtualCamera.Priority = 15;
            }
            if (Input.GetKeyUp(KeyCode.O))
            {
                code._virtualCamera.Priority = 1;
                code.ChangeState(new CodeUltimateState(code));
            }
            

            
        }
    }

    private void HandleMovement()
    {
        code.CheckGround();

        if (code.isGrounded && Input.GetKey(KeyCode.UpArrow))
        {
            code.rb.velocity = new Vector2(code.rb.velocity.x, code.jumpSpeed);
            code.verticalShootingDir = VerticalShootingDir.Up;
            code.ChangeFirePosition();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            code.verticalShootingDir = VerticalShootingDir.Normal;
            code.ChangeFirePosition();
            code.rb.velocity = new Vector2(-code.movementSpeed, code.rb.velocity.y);
            if (code.isFacingRight)
            {
                code.Flip();
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            code.verticalShootingDir = VerticalShootingDir.Normal;
            code.ChangeFirePosition();
            code.rb.velocity = new Vector2(code.movementSpeed, code.rb.velocity.y);
            if (!code.isFacingRight)
            {
                code.Flip();
            }
        }

        else if(Input.GetKey(KeyCode.DownArrow))
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
