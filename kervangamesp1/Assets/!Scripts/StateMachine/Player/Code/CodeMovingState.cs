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
        code.CheckGround();

        if (code.isGrounded && Input.GetKey(KeyCode.UpArrow))
        {
            code.rb.velocity = new Vector2(code.rb.velocity.x, code.jumpSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            code.rb.velocity = new Vector2(-code.movementSpeed, code.rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            code.rb.velocity = new Vector2(code.movementSpeed, code.rb.velocity.y);
        }

        else
        {
            code.rb.velocity = new Vector2(0, code.rb.velocity.y);
        }
    }

    public override void OnStateUpdate()
    {
        
    }
}
