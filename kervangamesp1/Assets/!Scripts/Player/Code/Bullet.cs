using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private Code code;

    private Rigidbody2D rb;
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (code.GetIsVerticalShooting())
        {
            rb.velocity = transform.up * bulletSpeed;
        }
        else
        {
            rb.velocity = transform.right * bulletSpeed;
        }
        
    }
}
