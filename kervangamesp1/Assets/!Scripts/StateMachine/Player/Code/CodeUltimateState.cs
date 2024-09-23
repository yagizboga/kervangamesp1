using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CodeUltimateState : CodeState
{
    public CodeUltimateState(Code code) : base(code)
    {

    }

    public override void OnStateEnter()
    {
        GiveDamageToEnemy();
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

    private void GiveDamageToEnemy() // float damage
    {
        // Enemy enemy = FindHighestHealthEnemy();
        //enemy.TakeDamage(damage);
    }

    private void FindHighestHealthEnemy()
    {
        //Enemy maxHealthEnemy = null;

        foreach (var enemy in code._ultimateEnemyList)
        {
            // float current = enemy.health;
            // if(current > max)
            // {
            //      maxHealthEnemy = enemy;
            // }    
        }

        // return maxHealthEnemy;
    }
}
