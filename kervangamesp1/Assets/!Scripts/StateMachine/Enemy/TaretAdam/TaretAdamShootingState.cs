using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class TaretAdamShootingState : TaretAdamState
{
    public TaretAdam TaretAdam;
    EnemyBulletSpawner bulletSpawner;
    int BulletCombinationChoice = 1;
    public TaretAdamShootingState(TaretAdam TaretAdam):base(TaretAdam){
        this.TaretAdam = TaretAdam;
        bulletSpawner = taretAdam.GetComponent<EnemyBulletSpawner>();
    }

    public override void OnStateEnter()
    {
        Debug.Log("Shooting State");
        bulletSpawner.StartEnemyCoroutine(Shooting());
    }

    public override void OnStateUpdate()
    {
    }

    public override void OnStateFixedUpdate()
    {

    }

    public override void OnStateExit()
    {

    }
    public IEnumerator Shooting(){
        
        while(true){
            int a = Random.Range(1,4);
            if(a ==1){
                yield return bulletSpawner.SpawnBullet(taretAdam.BlackBullet,taretAdam.BulletPosition1.position,taretAdam.BulletPosition1.rotation,0f);
                yield return bulletSpawner.SpawnBullet(taretAdam.OrangeBullet,taretAdam.BulletPosition3.position,taretAdam.BulletPosition1.rotation,1f);
                yield return bulletSpawner.SpawnBullet(taretAdam.BlueBullet,taretAdam.BulletPosition3.position,taretAdam.BulletPosition1.rotation,0f);
            }
            else if(a ==2){
                yield return bulletSpawner.SpawnBullet(taretAdam.OrangeBullet,taretAdam.BulletPosition1.position,taretAdam.BulletPosition1.rotation,0f);
                yield return bulletSpawner.SpawnBullet(taretAdam.BlueBullet,taretAdam.BulletPosition2.position,taretAdam.BulletPosition1.rotation,0f);
                yield return bulletSpawner.SpawnBullet(taretAdam.BlackBullet,taretAdam.BulletPosition3.position,taretAdam.BulletPosition1.rotation,0f);
            }
            else if(a ==3){
                yield return bulletSpawner.SpawnBullet(taretAdam.BlueBullet,taretAdam.BulletPosition2.position,taretAdam.BulletPosition1.rotation,0.5f);
                yield return bulletSpawner.SpawnBullet(taretAdam.BlueBullet,taretAdam.BulletPosition2.position,taretAdam.BulletPosition1.rotation,0.5f);
                yield return bulletSpawner.SpawnBullet(taretAdam.BlueBullet,taretAdam.BulletPosition2.position,taretAdam.BulletPosition1.rotation,0.5f);
                yield return bulletSpawner.SpawnBullet(taretAdam.BlueBullet,taretAdam.BulletPosition2.position,taretAdam.BulletPosition1.rotation,0.5f);
                yield return bulletSpawner.SpawnBullet(taretAdam.BlueBullet,taretAdam.BulletPosition2.position,taretAdam.BulletPosition1.rotation,0.5f);
            }
        }
    }
}



