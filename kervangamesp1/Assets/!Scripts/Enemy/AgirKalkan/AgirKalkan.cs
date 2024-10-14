using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgirKalkan : StateMachine
{
    public bool DetectionAreaBool = false;
    public float Speed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DetectionAreaBool){
            transform.position = new Vector2(Mathf.Lerp(transform.position.x,GameObject.FindGameObjectWithTag("Blade").transform.position.x,Speed),0);
        }
    }
}
