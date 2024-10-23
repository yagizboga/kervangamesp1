using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cinemachine;
using UnityEngine;

public class BladeAttackState : BladeState
{
    private float animationTime = .5f;
    private float timer = 0; 
    public BladeAttackState(Blade blade) : base(blade)
    {

    }

    public override void OnStateEnter()
    {
        Attack();
    }

    public override void OnStateExit()
    {
        blade.animator.SetBool("isCombo1", false);
        blade.animator.SetBool("isCombo2", false);
        blade.animator.SetBool("isCombo3", false);
    }

    public override void OnStateFixedUpdate()
    {

    }

    public override void OnStateUpdate()
    {
        if (timer >= animationTime) blade.ChangeState(new BladeIdleState(blade));
        
        if (timer <= animationTime)
        {
            timer += Time.deltaTime;
        }
    }

    private void Attack()
    {        
        switch (blade.currentComboNumber)
        {
            case 1:
                blade.animator.SetBool("isCombo1", true);
                BladeComboManager.Instance.StartBladeComboTimer();
            break;

            case 2:
                blade.animator.SetBool("isCombo2", true);
                BladeComboManager.Instance.StartBladeComboTimer();
            break;
                
            case 3:
                blade.animator.SetBool("isCombo3", true);
                BladeComboManager.Instance.StopBladeComboTimer();
            break;
        }

        if (blade.enemiesList.Count <= 0) return;

        foreach (var enemy in blade.enemiesList)
        {
            if (blade.executionPoint < blade.maxExecutionPoint)
            {
                blade.executionPoint++;
            }
            enemy.TakeDamage(blade.attackDamage);
        }
    }

    private void OnDrawGizmosSelected() 
    {
        if (blade.attackPoint == null) return;

        Gizmos.DrawWireSphere(blade.attackPoint.position, blade.attackRange);
    }

}

