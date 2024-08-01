using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : Player
{
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = new CodeMovingState(this);    
    }
}
