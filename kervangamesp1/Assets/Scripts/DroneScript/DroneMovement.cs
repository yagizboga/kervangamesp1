using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public Transform BladeTransform;
    public Transform CodeTransform;
    public float DroneSpeed;
    int CharacterChoice;
    int BulletChoice;
    public GameObject BlueBullet;
    public GameObject OrangeBullet;
    public Transform BulletSpawnTransform;

    void Start()
    {
        CharacterChoice = Random.Range(1,3);
        if(CharacterChoice == 1){
            StartCoroutine(TrackPlayer(BladeTransform));
        }
        else if(CharacterChoice == 2){
            StartCoroutine(TrackPlayer(CodeTransform));
        }

        StartCoroutine(DropBomb());
    }

    void Update()
    {
        
    }

    IEnumerator DropBomb(){
        yield return new WaitForSeconds(6f);
        while(true){
            BulletChoice = Random.Range(1,3);
            if(BulletChoice == 1){
                Instantiate(BlueBullet,BulletSpawnTransform.position,BulletSpawnTransform.rotation);
                yield return new WaitForSeconds(6f);
            }
            else if(BulletChoice == 2){
                Instantiate(OrangeBullet,BulletSpawnTransform.position,BulletSpawnTransform.rotation);
                yield return new WaitForSeconds(6f);
            }
        }

    }
    IEnumerator TrackPlayer(Transform CharacterTransform){
        while(true){
        float NewPositionX = Mathf.Lerp(transform.position.x,CharacterTransform.position.x,DroneSpeed*Time.deltaTime);
        transform.position = new Vector3(NewPositionX,transform.position.y,transform.position.z);
        if(Mathf.Abs(CharacterTransform.position.x - transform.position.x) <=0.2f){
            yield return new WaitForSeconds(1f);
        }
        yield return null;
        }
    }

    
}
