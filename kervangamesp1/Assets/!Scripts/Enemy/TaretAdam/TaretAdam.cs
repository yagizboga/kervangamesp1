using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretAdam : StateMachine
{
    private TaretAdamAwakeState awakeState;
    public Rigidbody2D rb;
    public float RiseSpeed = 5f;
    public float RiseHeight = -10f;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        awakeState = new TaretAdamAwakeState(this);
    }

    void Start(){
        ChangeState(awakeState);
    }

    void TakeDamage(float damage){
        
    }
}
