using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneShootingState : DroneState
{
    Drone Drone;
    float DroneSpeed = 3f;
    int CharacterChoice;
    public DroneShootingState(Drone Drone):base(Drone){
        this.Drone = Drone;
    }
    public override void OnStateEnter(){
        CharacterChoice = Random.Range(1,3);
        if(CharacterChoice == 1){
            drone.StartCoroutine(TrackPlayer(drone.BladeTransform));
        }
        else if(CharacterChoice == 2){
            drone.StartCoroutine(TrackPlayer(drone.CodeTransform));
        }

        drone.StartCoroutine(dronAnim());
    }
    public override void OnStateUpdate(){
    }


    public override void OnStateFixedUpdate(){
        if(drone.isShooting){
            GameObject.Instantiate(bulletchoice(),drone.BulletSpawnTransform.position,drone.BulletSpawnTransform.rotation);
            drone.isShooting =false;
        }
    }
    public override void OnStateExit(){}

    public IEnumerator TrackPlayer(Transform CharacterTransform){
        while(true){
        float NewPositionX = Mathf.Lerp(drone.transform.position.x,CharacterTransform.position.x,DroneSpeed*Time.deltaTime);
        drone.transform.position = new Vector3(NewPositionX,drone.transform.position.y,drone.transform.position.z);
        if(Mathf.Abs(CharacterTransform.position.x - drone.transform.position.x) <=0.2f){
            yield return new WaitForSeconds(1f);
        }
        yield return null;
        }
    }

    public IEnumerator dronAnim(){
        while(true){
            yield return new WaitForSeconds(5f);
            drone.GetComponent<Animator>().Play("Base Layer.Shooting",default,0f);
            Debug.Log("Shoot");
        }
        
        
    }

    GameObject bulletchoice(){
        int bulletc = Random.Range(1,3);
        if(bulletc ==1){
            return drone.BlueBullet;
        }
        return drone.OrangeBullet; 
    }


}
