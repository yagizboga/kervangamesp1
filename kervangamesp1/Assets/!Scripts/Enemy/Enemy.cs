using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateMachine, IDamagable
{
    public float Health;
    public bool isDead = false;

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        Health -= damage;

        if (Health <= 0)
        {
            isDead = true;
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
