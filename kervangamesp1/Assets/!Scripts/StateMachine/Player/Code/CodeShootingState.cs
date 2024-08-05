using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeShootingState : CodeState
{
    public CodeShootingState(Code code) : base(code)
    {

    }

    public override void OnStateEnter()
    {
        code.Shoot();
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
