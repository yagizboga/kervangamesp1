using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 vecGravity;

    private void Awake() {
        vecGravity = new Vector3(0, -Physics2D.gravity.y, 0);
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        isGrounded = Physics.CheckCapsule(groundCheck.position, groundCheck.position + Vector3.down * 0.1f, 0.5f, groundLayer);
        rb.velocity = new Vector3(movementSpeed * moveHorizontal, rb.velocity.y, 0);
        
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, 0);        
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }

        
    }
}
