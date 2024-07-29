using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMovement : PlayerMovement
{
    private void FixedUpdate() {
        MoveBlade();
    }
    private void MoveBlade()
    {
        CheckGround();
        
        if (isGrounded && Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
