using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaretAdam : Enemy
{
    public TaretAdamAwakeState awakeState;
    public TaretAdamShootingState shootingState;
    public Rigidbody2D rb;
    public float RiseSpeed = 1.5f;
    public float RiseHeight = 3f;
    public Transform BulletPosition1;
    public Transform BulletPosition2;
    public Transform BulletPosition3;
    public GameObject BlackBullet;
    public GameObject BlueBullet;
    public GameObject OrangeBullet;
    public bool TriggerEntered = false;
    public bool CanShoot = false;

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
            TriggerEntered = false;
        }
    }

    void Shoot(){
        CanShoot = true;
    }

  



}
