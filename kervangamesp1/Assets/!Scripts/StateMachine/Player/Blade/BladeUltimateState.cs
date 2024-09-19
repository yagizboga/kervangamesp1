using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeUltimateState : BladeState
{
    public BladeUltimateState(Blade blade) : base(blade)
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
        }
    }
}
