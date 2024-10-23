using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BladeParryManager : MonoBehaviour
{
    public static BladeParryManager Instance;

    public List<GameObject> parriedObjects;

    private void Awake() 
    {
        Instance = this;    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            parriedObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            parriedObjects.Remove(other.gameObject);
        }
    }
}
