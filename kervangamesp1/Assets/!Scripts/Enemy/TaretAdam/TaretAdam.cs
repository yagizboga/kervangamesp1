using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretAdam : StateMachine
{
    private TaretAdamAwakeState awakeState;
    private TaretAdamShootingState shootingState;
    public Rigidbody2D rb;
    public float RiseSpeed = 15f;
    public float RiseHeight = -10f;
    public Transform BulletPosition1;
    public Transform BulletPosition2;
    public Transform BulletPosition3;
    public GameObject BlackBullet;
    public GameObject BlueBullet;
    public GameObject OrangeBullet;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        awakeState = new TaretAdamAwakeState(this);
        shootingState = new TaretAdamShootingState(this);
    }

    void Start(){
        ChangeState(awakeState);
    }

    void TakeDamage(float damage){
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blade") || other.CompareTag("Code"))
        {
            if (CurrentState == awakeState)
            {
                awakeState.TriggerRise(RiseSpeed);          
            }
        }
    }



}
