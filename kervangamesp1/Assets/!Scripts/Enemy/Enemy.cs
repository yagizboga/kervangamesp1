using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HackableEnemyType
{
    Projectile, Barrier, Stun,
}

public class Enemy : StateMachine, IDamagable
{
    public float Health;
    public bool isDead = false;

    public void GetHacked(HackableEnemyType hackableEnemyType)
    {
        switch (hackableEnemyType)
        {
            case HackableEnemyType.Projectile:
                ProjectileHacked();
            break;

            case HackableEnemyType.Barrier:
                BarrierHacked();
            break;

            case HackableEnemyType.Stun:
                StunHacked();
            break;

        }
    }

    private void ProjectileHacked()
    {
        Debug.Log("Projectile Hacked");
        // Destroy(this, 1f);
    }

    private void BarrierHacked()
    {
        Debug.Log("Barrier Hacked");
        // gameobject.SetActive(false);
    }

    public void StunHacked()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

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
        if(!gameObject.CompareTag("KosanAdam")){
            Destroy(gameObject);
        }
        
    }

}
