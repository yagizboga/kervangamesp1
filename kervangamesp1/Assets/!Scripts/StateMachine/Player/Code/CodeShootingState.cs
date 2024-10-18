using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeShootingState : CodeState
{
    private float animationTime = .5f;
    private float timer = 0; 
    public CodeShootingState(Code code) : base(code)
    {

    }

    public override void OnStateEnter()
    {
        code.animator.SetBool("isCodeShooting", true);
        code.Shoot();
    }

    public override void OnStateExit()
    {
        code.animator.SetBool("isCodeShooting", false);
    }

    public override void OnStateFixedUpdate()
    {
        
    }

    public override void OnStateUpdate()
    {
        if (timer >= animationTime) code.ChangeState(new CodeIdleState(code));
        
        if (timer <= animationTime)
        {
            timer += Time.deltaTime;
        }
    }

}
