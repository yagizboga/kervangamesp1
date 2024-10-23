using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public enum VerticalShootingDir
{
    Normal, Up, Down
}

public class Player : StateMachine, IDamagable
{
    [Header("Player Attributes")]
    public float health;
    public float movementSpeed;
    public float jumpSpeed;
    public float fallMultiplier;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask enemyLayer;

    public bool isGrounded;
    public bool isFacingRight = true;
    public VerticalShootingDir verticalShootingDir;

    public TextMeshProUGUI healthText;
    
    public bool isAlive = true;
    public CinemachineVirtualCamera _virtualCamera;

    public void CheckGround() {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1, 0.5f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
    
    public void TakeDamage(float damage)
    {
        if (isAlive)
        {
            Debug.Log("Can: " + health);
            StartCoroutine(SlowDownTime());
            health -= damage;

            healthText.text = health.ToString();

            if (health <= 0)
            {
                isAlive = false;
                gameObject.SetActive(false);
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
