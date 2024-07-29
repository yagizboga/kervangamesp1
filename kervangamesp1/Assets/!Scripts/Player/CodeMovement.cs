using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeMovement : PlayerMovement
{
    private void FixedUpdate() {
        MoveCode();
    }
    private void MoveCode()
    {
        CheckGround();

        if (isGrounded && Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
