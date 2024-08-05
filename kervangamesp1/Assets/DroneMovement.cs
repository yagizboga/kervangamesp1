using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public Transform BladeTransform;
    public Transform CodeTransform;
    public float DroneSpeed;
    int CharacterChoice;

    void Start()
    {
        CharacterChoice = Random.Range(1,3);
        if(CharacterChoice == 1){
            StartCoroutine(TrackPlayer(BladeTransform));
        }
        else if(CharacterChoice == 2){
            StartCoroutine(TrackPlayer(CodeTransform));
        }
    }

    void Update()
    {
        
    }

    void DropBomb(){

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
