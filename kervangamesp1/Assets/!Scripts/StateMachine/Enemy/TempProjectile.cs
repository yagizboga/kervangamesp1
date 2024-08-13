using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempProjectile : MonoBehaviour
{
    Rigidbody2D rb;

    public bool _isHacked = false;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isHacked)
        {
            rb.velocity = new Vector2(-2, 0);
        }
    }
}
