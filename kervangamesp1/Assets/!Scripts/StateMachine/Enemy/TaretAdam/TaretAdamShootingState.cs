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
    //IEnumerator ShootingCombination(){
    //    BulletCombinationChoice = Random.Range(1,4);
    //    yield return new WaitForSeconds(10f);
   // }
    public IEnumerator Shooting(){
        while(true){
            
            yield return bulletSpawner.SpawnBullet(taretAdam.BlackBullet,taretAdam.BulletPosition1.position,taretAdam.BulletPosition1.rotation,1.5f);
            yield return bulletSpawner.SpawnBullet(taretAdam.BlackBullet,taretAdam.BulletPosition3.position,taretAdam.BulletPosition3.rotation,1.5f);
            yield return bulletSpawner.SpawnBullet(taretAdam.BlackBullet,taretAdam.BulletPosition2.position,taretAdam.BulletPosition2.rotation,1.5f);
            yield return bulletSpawner.SpawnBullet(taretAdam.BlackBullet,taretAdam.BulletPosition2.position,taretAdam.BulletPosition2.rotation,1.5f);
            yield return bulletSpawner.SpawnBullet(taretAdam.BlackBullet,taretAdam.BulletPosition2.position,taretAdam.BulletPosition2.rotation,1.5f);
        }
    }
}


