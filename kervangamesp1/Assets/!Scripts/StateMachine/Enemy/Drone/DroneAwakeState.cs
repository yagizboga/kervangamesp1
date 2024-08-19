using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAwakeState : DroneState
{
    Drone Drone;
    public DroneAwakeState(Drone Drone):base(Drone){
        this.Drone = Drone;
    }

    public override void OnStateEnter(){
        Debug.Log("awake");
    }
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}
}
