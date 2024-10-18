using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeHackState : CodeState
{
    private Rigidbody2D _projectileRb;
    public CodeHackState(Code code) : base(code)
    {

    }

    public override void OnStateEnter()
    {
        code.animator.SetBool("isCodeHack", true);
        _projectileRb = GetNearesProjectileObject().GetComponent<Rigidbody2D>();
        _projectileRb.GetComponent<TempProjectile>()._isHacked = true;
    }

    public override void OnStateExit()
    {
        code.animator.SetBool("isCodeHack", false);
        _projectileRb.GetComponent<TempProjectile>()._isHacked = false;
    }

    public override void OnStateFixedUpdate()
    {

    }

    public override void OnStateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            code.ChangeState(new CodeIdleState(code));
        }

        HandleProjectileMovement();
    }

    private void HandleProjectileMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _projectileRb.velocity = new Vector2(0, 2);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _projectileRb.velocity = new Vector2(0, -2);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _projectileRb.velocity = new Vector2(-2, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _projectileRb.velocity = new Vector2(2, 0);
        }
    }

    private GameObject GetNearesProjectileObject()
    {
        GameObject _closestProjectile = null;

        float minDistance = Mathf.Infinity;

        foreach (var projectile in code._hackableProjectilesList)
        {
            float distance = Vector3.Distance(code.transform.position, projectile.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                _closestProjectile = projectile;
            }
        }

        return _closestProjectile;
    }
}
