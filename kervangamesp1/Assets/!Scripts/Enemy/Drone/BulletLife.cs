using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletLife : MonoBehaviour
{

    void Update()
    {
        
    }

    void OnTriggerEnter2D(){
        Destroy(gameObject);
    }
}
