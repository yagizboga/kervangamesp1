using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeIdleState : CodeState
{
    public CodeIdleState(Code code) : base(code)
    {

    }
    public override void OnStateEnter()
    {
        code.animator.SetBool("isCodeIdle", true);
    }

    public override void OnStateExit()
    {
        code.animator.SetBool("isCodeIdle", false);
    }

    public override void OnStateFixedUpdate()
    {

    }

    public override void OnStateUpdate()
    {
        CodeMovement();

        CodeAttack();

        CodeHack();
    }

    private void CodeMovement()
    {
        if (Input.GetKey(code.jumpKey) || Input.GetKey(code.moveLeftKey) || Input.GetKey(code.crouchKey) || Input.GetKey(code.moveRightKey))
        {
            code.ChangeState(new CodeMovingState(code));
        }
    }

    private void CodeAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            code.ChangeState(new CodeShootingState(code));   
        }
    }

    private void CodeHack()
    {
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
}
