using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : Player
{   
    [SerializeField] protected GameObject firePoint;
    [SerializeField] protected GameObject bulletPrefab;

    private bool isVerticalShooting = false;
    private Transform orginalShootingDir;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();

        orginalShootingDir = firePoint.transform;
        
        currentState = new CodeMovingState(this);    
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }

    public void ChangeFirePosition()
    {
        switch (verticalShootingDir)
        {
            default:
                isVerticalShooting = false;
                firePoint.transform.localPosition = new Vector3(0.5f, 0, 0);
            break;
            case VerticalShootingDir.Up:
                isVerticalShooting = true;
                firePoint.transform.localPosition = new Vector3(0, 0.5f, 0);
            break;
            case VerticalShootingDir.Down:
                isVerticalShooting = false;
                firePoint.transform.localPosition = new Vector3(0.5f, -0.25f, 0);
            break;
        }
    }

    public bool GetIsVerticalShooting()
    {
        return isVerticalShooting;
    }
}
