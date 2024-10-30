using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaretAdam : Enemy
{
    public TaretAdamAwakeState awakeState;
    public TaretAdamShootingState shootingState;
    public Rigidbody2D rb;
    public float Speed = 1.5f;
    public Transform BulletPosition1;
    public Transform BulletPosition2;
    public Transform BulletPosition3;
    public GameObject BlackBullet;
    public GameObject BlueBullet;
    public GameObject OrangeBullet;
    public bool TriggerEntered = false;
    public bool CanShoot = false;
    public bool isanimstarted = false;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        awakeState = new TaretAdamAwakeState(this);
        shootingState = new TaretAdamShootingState(this);
    }

    void Start(){
        ChangeState(awakeState);
    }

    void Update(){
        if(TriggerEntered && (CurrentState == awakeState)){
            ChangeState(shootingState);
        }
    }

    void Shoot(){
        CanShoot = true;
    }

    void animtrue(){
        isanimstarted = true;
    }
    void animfalse(){
        isanimstarted =false;
    }

  



}
