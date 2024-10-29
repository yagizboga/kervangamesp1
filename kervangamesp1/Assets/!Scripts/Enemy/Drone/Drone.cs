using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Enemy
{
    private DroneAwakeState awakeState;
    private DroneShootingState shootingState;
    public  Transform BladeTransform;
    public  Transform CodeTransform;
    public GameObject BlueBullet;
    public GameObject OrangeBullet;
    public Transform BulletSpawnTransform;
    GameObject Blade;
    GameObject Code;
    public bool isShooting = false;
    public bool triggerarea = false;

    private void Awake(){
        awakeState = new DroneAwakeState(this);
        shootingState = new DroneShootingState(this);
        Blade = GameObject.FindGameObjectWithTag("Blade");
        Code = GameObject.FindGameObjectWithTag("Code");
        BladeTransform = Blade.transform;
        CodeTransform = Code.transform;
    }

    void Start(){
        ChangeState(awakeState);
    }

    public void Update(){
        if(isShooting){
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Assets/Assets/Enemy/Drone/BOMBER DRONE/IMG_0668.PNG") as Sprite;
        }
        else{
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Assets/Assets/Enemy/Drone/BOMBER DRONE/IMG_0667.PNG") as Sprite;
        }
        if(CurrentState==awakeState && triggerarea){
            ChangeState(shootingState);
        }
    }

    void TakeDamage(int damage){
        
    }


    public void canShoot(){
        isShooting = true;
    }
}
