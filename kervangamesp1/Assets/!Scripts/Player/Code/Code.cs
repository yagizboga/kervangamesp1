using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : Player
{   
    [SerializeField] protected GameObject firePoint;
    [SerializeField] protected Bullet bullet;
    public bool _isHackable = false;
    public List<GameObject> _hackableProjectilesList;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        
        currentState = new CodeMovingState(this);    
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
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Projectile"))
        {
            foreach (var projectile in _hackableProjectilesList)
            {
                if (projectile == other.gameObject)
                {
                    _hackableProjectilesList.Remove(projectile);
                    break;
                }
            }
        }
    }


}