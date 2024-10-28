using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeGrabManager : MonoBehaviour
{
    [SerializeField] float releaseCoolDown = 3f;
    public static CodeGrabManager Instance;
    public bool isCodeGrab = false;
    public bool isCodeRelease = false;
    private float timer = 0;
    private void Awake()
    {
        Instance = this;
    }

    private void Update() 
    {
        if (isCodeRelease)
        {
            if (timer <= releaseCoolDown)
            {
                isCodeGrab = false;
                timer += Time.deltaTime;
            }
            if (timer >= releaseCoolDown)
            {
                timer = 0;
                isCodeRelease = false;
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
