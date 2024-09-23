using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeExecutionState : BladeState
{
    public float executionTimer = 3f;
    public BladeExecutionState(Blade blade) : base(blade)
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

    }

    public override void OnStateUpdate()
    {
        CountDown();
    }

    private void CountDown()
    {
        if (executionTimer <= 0)
        {
            blade.ChangeState(new BladeMovingState(blade));
        }

        executionTimer -= Time.deltaTime;
    }
}
