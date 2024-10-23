using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeGrabManager : MonoBehaviour
{
    [SerializeField] float releaseCoolDown = 3f;
    public static CodeGrabManager Instance;
    public bool isCodeGrab = false;
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
            isCodeGrab = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("GrabObject"))
        {
            isCodeGrab = false;    
        }    
    }
}
