using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeStunState : CodeState
{
    private Rigidbody2D _enemyRb;
    public CodeStunState(Code code) : base(code)
    {

    }

    public override void OnStateEnter()
    {
        _enemyRb = GetNearestStunEnemy().GetComponent<Rigidbody2D>();
        _enemyRb.velocity = Vector3.zero;

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


    private GameObject GetNearestStunEnemy()
    {
        GameObject _closestEnemy = null;

        float minDistance = Mathf.Infinity;

        foreach (var enemy in code._stunEnemyList)
        {
            float distance = Vector3.Distance(code.transform.position, enemy.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                _closestEnemy = enemy;
            }
        }

        return _closestEnemy;
    }
}
