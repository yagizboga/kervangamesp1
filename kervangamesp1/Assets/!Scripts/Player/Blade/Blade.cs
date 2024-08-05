using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : Player
{
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = new BladeMovingState(this);    
    }
}
