using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeGrabState : BladeState
{
    public BladeGrabState(Blade blade) : base(blade)
    {

    }
    public override void OnStateEnter()
    {
        blade.animator.SetBool("isBladeGrab", true);
        blade.rb.gravityScale = 0;
    }

    public override void OnStateExit()
    {
        blade.animator.SetBool("isBladeGrab", false);
        BladeGrabManager.Instance.isBladeRelease = true;
        blade.rb.gravityScale = 1.75f;
    }

    public override void OnStateFixedUpdate()
    {

    }

    public override void OnStateUpdate()
    {
        if (!BladeGrabManager.Instance.isBladeGrab) blade.ChangeState(new BladeIdleState(blade));
        
        HandleGrabMovement();
    }

    private void HandleGrabMovement()
    {
        if (Input.GetKey(blade.jumpKey) || Input.GetKey(blade.crouchKey))
        {
            blade.ChangeState(new BladeIdleState(blade));
        }

        else if (Input.GetKey(blade.moveLeftKey))
        {
            blade.rb.velocity = new Vector2(-blade.movementSpeed, 0);
                        
            if (blade.isFacingRight)
            {
                blade.spriteRenderer.flipX = true;
                blade.Flip();
            }
        }

        else if (Input.GetKey(blade.moveRightKey))
        {
            blade.rb.velocity = new Vector2(blade.movementSpeed, 0);

            if (!blade.isFacingRight)
            {
                blade.spriteRenderer.flipX = false;
                blade.Flip();
            }
        }

        else
        {
            blade.rb.velocity = Vector2.zero;
        }



    }
}
