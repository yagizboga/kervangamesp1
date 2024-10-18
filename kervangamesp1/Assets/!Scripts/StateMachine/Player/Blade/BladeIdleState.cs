using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class BladeIdleState : BladeState
{
    public BladeIdleState(Blade blade) : base(blade)
    {

    }

    public override void OnStateEnter()
    {
        blade.animator.SetBool("isBladeIdle", true);
    }

    public override void OnStateExit()
    {
        blade.animator.SetBool("isBladeIdle", false);
    }

    public override void OnStateFixedUpdate()
    {

    }

    public override void OnStateUpdate()
    {        
        BladeMovement();
        
        BladeAttack(blade.attackKey);

        BladeExecution(blade.executionKey);

        BladeUltimatePress(blade.ultimateKey);
        BladeUltimateRelease(blade.ultimateKey);
    }

    private void BladeMovement()
    {
        if (Input.GetKey(blade.jumpKey) || Input.GetKey(blade.moveLeftKey) || Input.GetKey(blade.crouchKey) || Input.GetKey(blade.moveRightKey))
        {
            blade.ChangeState(new BladeMovingState(blade));
        }
    }

    private void BladeAttack(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
            blade.ChangeState(new BladeAttackState(blade));
        }
    }
    
    private void BladeExecution(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (!blade.bossEnemy) return;
            blade.bossCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
            blade.bossCamera.Priority = 15;
            blade.ChangeState(new BladeExecutionState(blade));
        }
    }

    private void BladeUltimatePress(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
            blade._virtualCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
            blade._virtualCamera.Priority = 15;
        }
    }

    private void BladeUltimateRelease(KeyCode keyCode)
    {
        if (Input.GetKeyUp(keyCode))
        {
            blade._virtualCamera.Priority = 1;
            blade.ChangeState(new BladeUltimateState(blade));
        }
    }
}
