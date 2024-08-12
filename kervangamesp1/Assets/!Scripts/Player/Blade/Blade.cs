using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Blade : StateMachine
{
    private BladeMovementState movementState;
    public Rigidbody2D rb;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        movementState = new BladeMovementState(this);
    }

    void Start(){
        ChangeState(movementState);
    }

    void TakeDamage(float damage){
        
    }

    
}
