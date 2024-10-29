using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavanTopcusu : Enemy
{
    private HavanTopcusuAwakeState awakeState;
    public Rigidbody2D rb;
    private HavanTopcusuShootingState shootingState;
    private HavanTopcusuDeathState deathState;
    public Transform BulletPosition;
    public GameObject BlackBullet;
    public GameObject BlueBullet;
    public GameObject OrangeBullet;
    public EnemyBulletSpawner bulletSpawner;
    public GameObject Bullet;
    public bool TriggerArea = false;

    public List<GameObject> BladeProjectiles;
    public List<GameObject> CodeProjectiles;

    public bool canShootCode = false;
    public bool canShootBlade = false;
   

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        awakeState = new HavanTopcusuAwakeState(this);
        shootingState = new HavanTopcusuShootingState(this);
        deathState = new HavanTopcusuDeathState(this);
    }

    void Start(){
        ChangeState(awakeState);
        ListManager();
    }


    void ListManager(){
        BladeProjectiles = new List<GameObject>{BlackBullet,BlackBullet,BlueBullet};
        CodeProjectiles = new List<GameObject>{BlackBullet,OrangeBullet,OrangeBullet};
    }

    public void Update(){
        if (TriggerArea)
        {
            if (CurrentState == awakeState)
            {
                ChangeState(shootingState);
                GetComponent<Animator>().SetBool("isShooting",true);
            }
        }
        if(Health<= 0){
            ChangeState(deathState);
        }
    }
    


   

    public void ShootCode(){
        canShootCode =true;
    }
    public void ShootBlade(){
        canShootBlade = true;
    }   
    void DestroyHavanTopcusu(){
        Destroy(gameObject);
    }

    
}
