using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateMachine,Idamagable
{
    public float Health;
    public float Speed;

    public void TakeDamage(float Damage){
            Health-=Damage;
    }
}
