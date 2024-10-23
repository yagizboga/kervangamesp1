using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 20f;
    private bool isVerticalShooting = false;
    private Rigidbody2D rb;
    
    IDamagable damagable;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetVelocity();
        StartCoroutine(DestroyBullet());
    }

    private void SetVelocity()
    {
        if (isVerticalShooting)
        {
            rb.velocity = transform.up * bulletSpeed;
        }
        else
        {
            rb.velocity = transform.right * bulletSpeed;
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);     
    }

    public void SetIsVerticalShooting(bool _isVerticalShooting)
    {
        isVerticalShooting = _isVerticalShooting;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(25f);
            Destroy(this.gameObject);
         }
    }
}
