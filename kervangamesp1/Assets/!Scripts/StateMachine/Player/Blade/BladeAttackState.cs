using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BladeAttackState : BladeState
{
    public BladeAttackState(Blade blade) : base(blade)
    {

    }

    public override void OnStateEnter()
    {
        Attack();
        blade.ChangeState(new BladeMovingState(blade));
    }

    public override void OnStateExit()
    {

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

        if (blade.enemiesList.Count <= 0) return;

        foreach (var enemy in blade.enemiesList)
        {
            Debug.Log("Enemy Hitted");
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
