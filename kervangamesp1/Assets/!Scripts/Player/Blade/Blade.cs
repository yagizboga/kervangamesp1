using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Blade : Player
{
    [Header("Blade Attributes")]
    [Header("KeyCodes")]
    public KeyCode jumpKey = KeyCode.W;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode crouchKey = KeyCode.S;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode attackKey = KeyCode.Space;
    public KeyCode executionKey = KeyCode.F;
    public KeyCode ultimateKey = KeyCode.U;
    public KeyCode parryKey = KeyCode.P;
    public KeyCode grabKey = KeyCode.L;
    
    [Header("Execution")]
    public int executionPoint = 0;
    public int maxExecutionPoint = 5;

    [Header("Attack")]
    public Transform attackPoint;
    public float attackDamage = 25f;
    // public float criticAttackDamage ??????
    public float attackRange = 1f;
    public int currentComboNumber = 1;
    public float comboTimer = 5f;

    [Header("Enemies")]
    public LayerMask enemyLayers;
    public List<Enemy> enemiesList;
    public GameObject bossEnemy;
    public CinemachineVirtualCamera bossCamera;

    public bool isRageMode = false;

    private void Awake() 
    {
        health = 3;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        CurrentState = new BladeIdleState(this);    
    }

    public void ChangeAttackPoint()
    {
        switch (verticalShootingDir)
        {
            default:
                // bullet.SetIsVerticalShooting(false);
                attackPoint.transform.localPosition = new Vector3(1.0f, 0.5f, 0);
            break;
            case VerticalShootingDir.Up:
                // bullet.SetIsVerticalShooting(true);
                attackPoint.transform.localPosition = new Vector3(0, 1.5f, 0);
            break;
            case VerticalShootingDir.Down:
                // bullet.SetIsVerticalShooting(false);
                attackPoint.transform.localPosition = new Vector3(1.0f, -0.5f, 0);
            break;
        }
    }

    // TODO: Change the way of find enemy (Check layer of enemies rather than tag)
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesList.Add(other.GetComponent<Enemy>());
        }
        
        if (other.gameObject.CompareTag("Boss"))
        {
            bossEnemy = other.gameObject;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesList.Remove(other.GetComponent<Enemy>());
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            bossEnemy = null;
        }
    }
}
