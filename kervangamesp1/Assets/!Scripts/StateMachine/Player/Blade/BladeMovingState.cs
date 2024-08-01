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
        blade.CheckGround();
        
        if (blade.isGrounded && Input.GetKey(KeyCode.W))
        {
            blade.rb.velocity = new Vector2(blade.rb.velocity.x, blade.jumpSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            blade.rb.velocity = new Vector2(-blade.movementSpeed, blade.rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            blade.rb.velocity = new Vector2(blade.movementSpeed, blade.rb.velocity.y);
        }

        else
        {
            blade.rb.velocity = new Vector2(0, blade.rb.velocity.y);
        }
    }

    public override void OnStateUpdate()
    {
        
    }
}
