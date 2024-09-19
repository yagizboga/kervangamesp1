using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeUltimateState : CodeState
{
    public CodeUltimateState(Code code) : base(code)
    {

    }

    public override void OnStateEnter()
    {
        code.ChangeState(new CodeMovingState(code));
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
}
