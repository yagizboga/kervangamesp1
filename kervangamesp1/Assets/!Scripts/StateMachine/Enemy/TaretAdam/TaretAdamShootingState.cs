using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class TaretAdamShootingState : TaretAdamState
{
    public TaretAdam TaretAdam;
    TaretAdamBulletSpawner bulletSpawner;
    int BulletCombinationChoice = 1;
    public TaretAdamShootingState(TaretAdam TaretAdam):base(TaretAdam){
        this.TaretAdam = TaretAdam;
        bulletSpawner = taretAdam.GetComponent<TaretAdamBulletSpawner>();
    }

    public override void OnStateEnter()
    {
        Debug.Log("Shooting State");
        bulletSpawner.StartShootingCoroutine(Shooting());
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
            
            yield return bulletSpawner.SpawnBullet(taretAdam.BlackBullet,taretAdam.BulletPosition1);
            yield return bulletSpawner.SpawnBullet(taretAdam.BlackBullet,taretAdam.BulletPosition3);
            yield return bulletSpawner.SpawnBullet(taretAdam.BlueBullet,taretAdam.BulletPosition2);
            yield return bulletSpawner.SpawnBullet(taretAdam.BlueBullet,taretAdam.BulletPosition2);
            yield return bulletSpawner.SpawnBullet(taretAdam.OrangeBullet,taretAdam.BulletPosition2);
        }
    }
}



