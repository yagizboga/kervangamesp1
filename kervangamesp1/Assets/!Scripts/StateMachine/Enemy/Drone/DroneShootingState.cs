using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneShootingState : DroneState
{
    Drone Drone;
    float DroneSpeed = 3f;
    int CharacterChoice;
    int BulletChoice;
    EnemyBulletSpawner BulletSpawner;
    public DroneShootingState(Drone Drone):base(Drone){
        this.Drone = Drone;
    }
    public override void OnStateEnter(){
        BulletSpawner = drone.GetComponent<EnemyBulletSpawner>();
        Debug.Log("shooting");
        CharacterChoice = Random.Range(1,3);
        if(CharacterChoice == 1){
            BulletSpawner.StartEnemyCoroutine(TrackPlayer(drone.BladeTransform));
        }
        else if(CharacterChoice == 2){
            BulletSpawner.StartEnemyCoroutine(TrackPlayer(drone.CodeTransform));
        }
        BulletSpawner.StartEnemyCoroutine(DropBomb());
    }
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}

    public IEnumerator DropBomb(){
        yield return new WaitForSeconds(6f);
        while(true){
            BulletChoice = Random.Range(1,3);
            if(BulletChoice == 1){
                yield return BulletSpawner.SpawnBullet(drone.BlueBullet,drone.BulletSpawnTransform,6f);
            }
            else if(BulletChoice == 2){
                yield return BulletSpawner.SpawnBullet(drone.OrangeBullet,drone.BulletSpawnTransform,6f);
            }
        }

    }
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


}
