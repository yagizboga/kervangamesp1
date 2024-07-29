using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected float jumpSpeed;
    [SerializeField] protected float fallMultiplier;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected LayerMask groundLayer;
    protected Rigidbody2D rb;
    protected bool isGrounded;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void CheckGround() {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1, 0.5f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

}
