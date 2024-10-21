using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeGrabManager : MonoBehaviour
{
    [SerializeField] float releaseCoolDown = 3f;
    public static BladeGrabManager Instance;
    public bool isBladeGrab = false;
    private void Awake()
    {
        Instance = this;
    }

    private void Update() 
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GrabObject"))
        {
            isBladeGrab = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("GrabObject"))
        {
            isBladeGrab = false;    
        }    
    }
}
