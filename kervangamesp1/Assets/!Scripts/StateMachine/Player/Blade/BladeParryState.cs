using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeParryState : BladeState
{
    private float animationTime = .35f;
    private float timer = 0; 
    public BladeParryState(Blade blade) : base(blade)
    {

    }

    public override void OnStateEnter()
    {
        blade.animator.SetBool("isBladeParry", true);
    }

    public override void OnStateExit()
    {
        blade.animator.SetBool("isBladeParry", false);
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

        HandleParry();
    }

    private void HandleParry()
    {
        if (BladeParryManager.Instance.parriedObjects.Count <=0) return;

        foreach (var parriedObject in BladeParryManager.Instance.parriedObjects)
        {
            Destroy(parriedObject);
        }


    }
}
