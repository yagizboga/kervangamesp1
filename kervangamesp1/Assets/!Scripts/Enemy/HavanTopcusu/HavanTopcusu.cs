using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavanTopcusu : StateMachine
{
    private HavanTopcusuAwakeState awakeState;
    public Rigidbody2D rb;
    private HavanTopcusuShootingState shootingState;
    public Transform BulletPosition;
    public GameObject BlackBullet;
    public GameObject BlueBullet;
    public GameObject OrangeBullet;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        awakeState = new HavanTopcusuAwakeState(this);
        shootingState = new HavanTopcusuShootingState(this);
    }

    void Start(){
        ChangeState(awakeState);
    }

    void TakeDamage(float damage){
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (CurrentState == awakeState)
            {
                ChangeState(shootingState);
            }
        }
    }
}
