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
    public AgirKalkanDeathState deathState;
    public GameObject BrokenParts;


    void Awake(){
        bladeTrackingState = new AgirKalkanBladeTrackingState(this);
        deathState = new AgirKalkanDeathState(this);
    }
    void Start()
    {
        ChangeState(awakeState);
    }
   

    // Update is called once per frame
    void Update()
    {
        if(DetectionAreaBool && CurrentState == awakeState){
            ChangeState(bladeTrackingState);
            DetectionAreaBool = false;
            transform.Find("DetectionArea").GetComponent<BoxCollider2D>().enabled = false;
        }
        if(Health <= 0){
            ChangeState(deathState);
        }
    }


}
