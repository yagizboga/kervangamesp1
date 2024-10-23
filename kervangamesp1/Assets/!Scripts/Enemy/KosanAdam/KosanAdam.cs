using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KosanAdam : Enemy

{

private KosanAdamAwakeState AwakeState;
 public Rigidbody2D rb;
private KosanAdamShootingState shootingState;
public GameObject BlueBullet;
public GameObject SpawnPoint;

private void Awake(){
    rb = GetComponent<Rigidbody2D>();
    AwakeState = new KosanAdamAwakeState(this);
    shootingState = new KosanAdamShootingState(this);
    }
     void Start(){
        ChangeState(AwakeState);
    }
    void TakeDamage(float damage){
        
    }
   private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Blade") || other.CompareTag("Code"))
        {
            if (CurrentState == AwakeState)
            {
                ChangeState(shootingState);
            }
        }
    }

} 
