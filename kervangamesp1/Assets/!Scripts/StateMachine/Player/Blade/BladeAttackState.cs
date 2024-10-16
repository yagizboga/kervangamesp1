using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BladeAttackState : BladeState
{
    private int currentComboNumber;
    public BladeAttackState(Blade blade, int comboNumber) : base(blade)
    {
        currentComboNumber = comboNumber;
    }

    public override void OnStateEnter()
    {
        Attack();
        blade.ChangeState(new BladeIdleState(blade));
    }

    public override void OnStateExit()
    {
        blade.animator.SetBool("isComboCut", true);
        blade.animator.SetBool("isAttacking", false);
        blade.animator.SetBool("isCombo2", false);
        blade.animator.SetBool("isCombo3", false);
    }

    public override void OnStateFixedUpdate()
    {

    }

    public override void OnStateUpdate()
    {
        
    }

    private void Attack()
    {        
        // Animation
        Debug.Log("currentComboNumber: " + currentComboNumber);
        switch (currentComboNumber)
        {
            case 1:
                blade.animator.SetBool("isAttacking", true);
            break;

            case 2:
                blade.animator.SetBool("isCombo2", true);
            break;
                
            case 3:
                blade.animator.SetBool("isCombo3", true);
            break;
        }

        if (blade.enemiesList.Count <= 0) return;

        foreach (var enemy in blade.enemiesList)
        {
            if (blade.executionPoint < blade.maxExecutionPoint)
            {
                blade.executionPoint++;
            }
        }
    }

    private void OnDrawGizmosSelected() 
    {
        if (blade.attackPoint == null) return;

        Gizmos.DrawWireSphere(blade.attackPoint.position, blade.attackRange);
    }

}
