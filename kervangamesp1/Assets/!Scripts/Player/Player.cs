using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine, IDamagable
{
    public float movementSpeed;
    public float jumpSpeed;
    public float fallMultiplier;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    public bool isGrounded;

    public void CheckGround() {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1, 0.5f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
    
    public void TakeDamage(float damage)
    {

    }
}
