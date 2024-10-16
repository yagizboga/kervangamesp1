using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class BladeIdleState : BladeState
{
    private int currentComboNumber= 1;
    private bool isCombo1Done = false;
    private float timer = 0;
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
            timer = blade.comboTimer;

            if (currentComboNumber == 1)
            {
                Debug.Log("blade combo 1 entered");
                blade.ChangeState(new BladeAttackState(blade, currentComboNumber));
                currentComboNumber = 2;
            }

            else if (currentComboNumber == 2)
            {
                blade.ChangeState(new BladeAttackState(blade, currentComboNumber));
                currentComboNumber = 3;
            }

            else if (currentComboNumber == 3)
            {
                blade.ChangeState(new BladeAttackState(blade, currentComboNumber));
                currentComboNumber = 1;
            }
        }

        if (timer > 0)
        {
            Debug.Log(timer);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                currentComboNumber = 1;
            }
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
