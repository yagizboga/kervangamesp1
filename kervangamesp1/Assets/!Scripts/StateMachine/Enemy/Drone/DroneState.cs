using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneState : State
{
    protected Drone drone;

    public DroneState(Drone drone){
        this.drone = drone;
    }
    public virtual void OnStateEnter(){}
    public virtual void OnStateUpdate(){}
    public virtual void OnStateFixedUpdate(){}
    public virtual void OnStateExit(){}
}
