using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CyberP1TrackingLaserState : CyberState
{
    Cyber Cyber;
    Transform LaserStart;
    Transform LaserEnd;
    float LaserExpandSpeed = 3f;
    float CurrentWidth = 0.1f;
    float MaxWidth = 10f;


    MeshCollider collider;


    public CyberP1TrackingLaserState(Cyber Cyber):base(Cyber){
        this.Cyber = Cyber;
    }

    public override void OnStateEnter(){

        collider = cyber.GetComponent<MeshCollider>();

        if(collider == null){
            collider = cyber.AddComponent<MeshCollider>();
        }

        LaserStart = cyber.Body.transform;
        LaserEnd = Random.Range(0,2) == 0? cyber.CodeTransform:cyber.BladeTransform;

        cyber.TrackingLaser.startWidth = 0.1f;
        cyber.TrackingLaser.endWidth = 0.1f;
        cyber.TrackingLaser.material = new Material(Shader.Find("Sprites/Default"));
        cyber.TrackingLaser.startColor = Color.red;
        cyber.TrackingLaser.endColor = Color.red;
        cyber.TrackingLaser.positionCount = 2;
        
        if(LaserStart !=null){
            cyber.TrackingLaser.SetPosition(0,LaserStart.position);
        }
        if(LaserEnd != null){
            cyber.TrackingLaser.SetPosition(1,LaserEnd.position);
        }





    }
    public override void OnStateUpdate(){

        if(CurrentWidth < MaxWidth){
            CurrentWidth += LaserExpandSpeed * Time.deltaTime;
            cyber.TrackingLaser.endWidth = CurrentWidth;
            cyber.IsLaserFire = false;
        }
        else if(CurrentWidth >=MaxWidth){
            FireLaser();
            LaserEnd = Random.Range(0,2) == 0? cyber.CodeTransform:cyber.BladeTransform;
            CurrentWidth = 0.1f;

            if(LaserStart !=null){
            cyber.TrackingLaser.SetPosition(0,LaserStart.position);
            }
            if(LaserEnd != null){
                cyber.TrackingLaser.SetPosition(1,LaserEnd.position);
            }
        }

        GenerateMeshCollider();
        
    }
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}

    void FireLaser(){
        Debug.Log("Laser!");
        cyber.IsLaserFire = true;
    }

    void GenerateMeshCollider(){
        Mesh mesh = new Mesh();
        cyber.TrackingLaser.BakeMesh(mesh,true);
        collider.sharedMesh = mesh;
    }

    
    
}
