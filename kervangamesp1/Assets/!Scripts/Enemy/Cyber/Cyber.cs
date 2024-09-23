using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyber : StateMachine
{

    CyberAwakeState AwakeState;
    CyberP3ArmAttackState P3ArmAttackState;
    CyberP1LaserState P1LaserState;
    CyberP1TrackingLaserState P1TrackingLaserState;
    CyberP1ProjectileAttackState P1ProjectileAttackState;
    public GameObject CyberBlackBullet;
    public GameObject CyberBlueBullet;
    public GameObject CyberOrangeBullet;
    public GameObject CyberLaser;
    public GameObject CyberProjectile;
    public GameObject UpperArm;
    public GameObject ForeArm;
    public GameObject Body;
    public LineRenderer TrackingLaser;
    public Transform CodeTransform;
    public Transform BladeTransform;
    public bool IsLaserFire;
    public GameObject CyberP1ProjectilePosition1;
    public GameObject CyberP1ProjectilePosition2;
    public GameObject CyberP1ProjectilePosition3;
    public GameObject CyberP1ProjectilePosition4;
    public GameObject CyberP1ProjectilePosition5;

    public GameObject CyberP1LaserPosition1;
    public GameObject CyberP1LaserPosition2;
    public GameObject CyberP1LaserPosition3;
    public GameObject CyberP1LaserPosition4;
    public GameObject CyberP1LaserPosition5;


    void Awake(){
        AwakeState = new CyberAwakeState(this);
        P3ArmAttackState = new CyberP3ArmAttackState(this);
        P1LaserState = new CyberP1LaserState(this);
        P1TrackingLaserState = new CyberP1TrackingLaserState(this);
        P1ProjectileAttackState = new CyberP1ProjectileAttackState(this);
        TrackingLaser = gameObject.GetComponent<LineRenderer>();
    }
    void Start(){
        ChangeState(P1TrackingLaserState);
    }

    public void OnTriggerEnter(Collider other){
        Debug.Log("Collision");
        
    }
}