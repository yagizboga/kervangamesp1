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
    float LaserExpandSpeed = 0.4f;
    float CurrentWidth = 0.1f;
    float MaxWidth = 1f;
    Vector2 LaserDirection;
    float LaserDistance;
    RaycastHit2D hit;


    MeshCollider collider;


    public CyberP1TrackingLaserState(Cyber Cyber):base(Cyber){
        this.Cyber = Cyber;
    }

    public override void OnStateEnter(){
        if(cyber.TrackingLaser == null){
            cyber.TrackingLaser = cyber.gameObject.AddComponent<LineRenderer>();
        }
        cyber.TrackingLaser.enabled = true;
        
        

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
        
        }
    public override void OnStateFixedUpdate(){
        if(cyber.TrackingLaser!=null){
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
        }

        

        LaserDirection = (LaserEnd.position - LaserStart.position).normalized;
        LaserDistance = Vector2.Distance(LaserStart.position, LaserEnd.position);
    }
    public override void OnStateExit(){
        cyber.TrackingLaser.enabled = false;
    }

    void FireLaser(){
        hit = Physics2D.Raycast(LaserStart.position,LaserDirection,LaserDistance);
            if(hit.collider.CompareTag("Blade")){
                Debug.Log("Blade got shot");
            }
            if(hit.collider.CompareTag("Code")){
                Debug.Log("Code got shot");
            }
        cyber.IsLaserFire = true;
    }
}