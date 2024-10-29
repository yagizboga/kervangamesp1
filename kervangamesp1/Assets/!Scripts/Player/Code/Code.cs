using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : Player
{   
    [Header("Code Attributes")]
    [Header("KeyCodes")]
    public KeyCode jumpKey = KeyCode.RightShift;
    public KeyCode lookUpKey = KeyCode.UpArrow;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode crouchKey = KeyCode.DownArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode hackKey = KeyCode.E;

    [SerializeField] protected GameObject firePoint;
    [SerializeField] protected Bullet bullet;
    public bool _isHackable = false;
    public List<GameObject> _hackableProjectilesList;
    public List<GameObject> _barrierList;
    public List<GameObject> _stunEnemyList;
    public List<GameObject> _ultimateEnemyList;
    public GameObject _ridableDrone;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        CurrentState = new CodeIdleState(this);   
    }

    public void Shoot()
    {
        Bullet tempBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        if (verticalShootingDir == VerticalShootingDir.Up)
        {
            tempBullet.SetIsVerticalShooting(true);
        }
        else
        {
            tempBullet.SetIsVerticalShooting(false);
        }

        
        
    }

    public void ChangeFirePosition()
    {
        switch (verticalShootingDir)
        {
            default:
                // bullet.SetIsVerticalShooting(false);
                firePoint.transform.localPosition = new Vector3(0.5f, 0, 0);
            break;
            case VerticalShootingDir.Up:
                // bullet.SetIsVerticalShooting(true);
                firePoint.transform.localPosition = new Vector3(0, 0.5f, 0);
            break;
            case VerticalShootingDir.Down:
                // bullet.SetIsVerticalShooting(false);
                firePoint.transform.localPosition = new Vector3(0.5f, -0.25f, 0);
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Projectile"))
        {
            _hackableProjectilesList.Add(other.gameObject);
            _isHackable = true;
        }

        if (other.gameObject.CompareTag("Barrier"))
        {
            _barrierList.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("Stunnable"))
        {
            _stunEnemyList.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            _ultimateEnemyList.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("Drone"))
        {
            _ridableDrone = other.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Projectile"))
        {
            _hackableProjectilesList.Remove(other.gameObject);
        }

        if (other.gameObject.CompareTag("Barrier"))
        {
            _barrierList.Remove(other.gameObject);
        }

        if (other.gameObject.CompareTag("Stunnable"))
        {
            _stunEnemyList.Remove(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            _ultimateEnemyList.Remove(other.gameObject);
        }

        if (other.gameObject.CompareTag("Drone"))
        {
            _ridableDrone = null;
        }
    }


}
