using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavanTopcusu : Enemy
{
    private HavanTopcusuAwakeState awakeState;
    public Rigidbody2D rb;
    private HavanTopcusuShootingState shootingState;
    public Transform BulletPosition;
    public GameObject BlackBullet;
    public GameObject BlueBullet;
    public GameObject OrangeBullet;
    public EnemyBulletSpawner bulletSpawner;
    public GameObject Bullet;

    public List<GameObject> BladeProjectiles;
    public List<GameObject> CodeProjectiles;
    public int bulletcounter = 0;
    public int bulletOrder = 0;

   

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        awakeState = new HavanTopcusuAwakeState(this);
        shootingState = new HavanTopcusuShootingState(this);
        bulletSpawner = new EnemyBulletSpawner();
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
        if(bulletOrder%2==0){
            Bullet = BladeProjectiles[Random.Range(0,BladeProjectiles.Count)];
        }
        if(bulletOrder%2!=0){
            Bullet = CodeProjectiles[Random.Range(0,BladeProjectiles.Count)];
        }
    }
    


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blade")|| other.CompareTag("Code"))
        {
            if (CurrentState == awakeState)
            {
                ChangeState(shootingState);
                GetComponent<Animator>().SetBool("isShooting",true);
            }
        }
    }

    public void Shoot(){
        bulletSpawner.Spawn(Bullet,BulletPosition.position,BulletPosition.rotation);
        bulletcounter++;
        bulletOrder++;
    }

    
}
