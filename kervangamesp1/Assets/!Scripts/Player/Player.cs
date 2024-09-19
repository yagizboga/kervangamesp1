using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public enum VerticalShootingDir
{
    Normal, Up, Down
}

public class Player : StateMachine, IDamagable
{
    public int health;
    public float movementSpeed;
    public float jumpSpeed;
    public float fallMultiplier;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Rigidbody2D rb;

    public bool isGrounded;
    public bool isFacingRight = true;
    public VerticalShootingDir verticalShootingDir;
    
    public bool isAlive = true;
    public CinemachineVirtualCamera _virtualCamera;

    public void CheckGround() {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1, 0.5f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
    
    public void TakeDamage(float damage)
    {
        if (isAlive)
        {
            StartCoroutine(SlowDownTime());
            health--;

            if (health <= 0)
            {
                isAlive = false;
            }
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private IEnumerator SlowDownTime()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
    }
}
