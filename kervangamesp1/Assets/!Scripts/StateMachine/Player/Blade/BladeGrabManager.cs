using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeGrabManager : MonoBehaviour
{
    [SerializeField] float releaseCoolDown = 3f;
    public static BladeGrabManager Instance;
    public bool isBladeGrab = false;
    public bool isBladeRelease = false;
    private float timer = 0;
    private void Awake()
    {
        Instance = this;
    }

    private void Update() 
    {
        if (isBladeRelease)
        {
            if (timer <= releaseCoolDown)
            {
                isBladeGrab = false;
                timer += Time.deltaTime;
            }
            if (timer >= releaseCoolDown)
            {
                timer = 0;
                isBladeRelease = false;
            }
        }
        else
        {
            timer = 0;
        }
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
