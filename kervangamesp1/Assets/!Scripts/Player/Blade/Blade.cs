using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Blade : Player
{
    public int executionPoint = 0;
    public int maxExecutionPoint = 5;

    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public List<GameObject> enemiesList;
    public GameObject bossEnemy;
    public CinemachineVirtualCamera bossCamera;

    public bool isRageMode = false;

    private void Awake() 
    {
        health = 3;
        rb = GetComponent<Rigidbody2D>();
        currentState = new BladeMovingState(this);    
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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesList.Add(other.gameObject);
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
            enemiesList.Remove(other.gameObject);
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            bossEnemy = null;
        }
    }
}
