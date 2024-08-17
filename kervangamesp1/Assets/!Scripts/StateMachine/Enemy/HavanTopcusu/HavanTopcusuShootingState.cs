using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavanTopcusuShootingState : HavanTopcusuState
{
    public HavanTopcusu Havantopcusu;
    int BulletOrder;
    EnemyBulletSpawner bulletSpawner;

    

    public HavanTopcusuShootingState(HavanTopcusu Havantopcusu):base(Havantopcusu){
        this.Havantopcusu = Havantopcusu;
    }

    public override void OnStateEnter()
    {
        bulletSpawner = havanTopcusu.GetComponent<EnemyBulletSpawner>();
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

    public IEnumerator Shooting(){
        BulletOrder = Random.Range(1,4);
        while(true){
            if(BulletOrder == 1){
                yield return bulletSpawner.SpawnBullet(havanTopcusu.BlackBullet,havanTopcusu.BulletPosition,1.5f);
                yield return bulletSpawner.SpawnBullet(havanTopcusu.BlackBullet,havanTopcusu.BulletPosition,1.5f);
                yield return bulletSpawner.SpawnBullet(havanTopcusu.BlueBullet,havanTopcusu.BulletPosition,1.5f);
            }
            else if(BulletOrder == 2){
                yield return bulletSpawner.SpawnBullet(havanTopcusu.BlackBullet,havanTopcusu.BulletPosition,1.5f);
                yield return bulletSpawner.SpawnBullet(havanTopcusu.BlueBullet,havanTopcusu.BulletPosition,1.5f);
                yield return bulletSpawner.SpawnBullet(havanTopcusu.BlackBullet,havanTopcusu.BulletPosition,1.5f);
            }
            else if(BulletOrder == 3){
                yield return bulletSpawner.SpawnBullet(havanTopcusu.BlueBullet,havanTopcusu.BulletPosition,1.5f);
                yield return bulletSpawner.SpawnBullet(havanTopcusu.BlackBullet,havanTopcusu.BulletPosition,1.5f);
                yield return bulletSpawner.SpawnBullet(havanTopcusu.BlackBullet,havanTopcusu.BulletPosition,1.5f);
            }
        }
    }

}
