using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeDroneRidingManager : MonoBehaviour
{
    public bool isDroneRidable = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Code"))
        {
            isDroneRidable = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Code"))
        {
            isDroneRidable = false;
        }    
    }
}
