using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : StateMachine
{
    private DroneAwakeState awakeState;
    private DroneShootingState shootingState;
    public Rigidbody2D rb;
    public Transform BladeTransform;
    public Transform CodeTransform;
    public GameObject BlueBullet;
    public GameObject OrangeBullet;
    public Transform BulletSpawnTransform;
    GameObject Blade;
    GameObject Code;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        awakeState = new DroneAwakeState(this);
        shootingState = new DroneShootingState(this);
        Blade = GameObject.FindGameObjectWithTag("Blade");
        Code = GameObject.FindGameObjectWithTag("Code");
        BladeTransform = Blade.transform;
        CodeTransform = Code.transform;
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
                ChangeState(shootingState);
            }
        }
    }
}