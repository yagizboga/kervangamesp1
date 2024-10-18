using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgirKalkan : Enemy
{
    public bool DetectionAreaBool = false;
    public bool TrapDetectionAreaBool = false;
    public float agirKalkanSpeed = 4f;
    public GameObject Bluelight;
    public AgirKalkanAwakeState awakeState;
    public AgirKalkanBladeTrackingState bladeTrackingState;

    void Awake(){
        bladeTrackingState = new AgirKalkanBladeTrackingState(this);
    }
    void Start()
    {
        ChangeState(awakeState);
    }
   

    // Update is called once per frame
    void Update()
    {
        if(DetectionAreaBool){
            ChangeState(bladeTrackingState);
            DetectionAreaBool = false;
            transform.Find("DetectionArea").GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
