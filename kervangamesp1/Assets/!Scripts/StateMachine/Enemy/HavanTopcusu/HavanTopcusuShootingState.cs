using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavanTopcusuShootingState : HavanTopcusuState
{
    public HavanTopcusu Havantopcusu;
    int BulletOrder;
    List<GameObject> BladeProjectiles;
    List<GameObject> CodeProjectiles;

    EnemyBulletSpawner bulletSpawner;

    

    public HavanTopcusuShootingState(HavanTopcusu Havantopcusu):base(Havantopcusu){
        this.Havantopcusu = Havantopcusu;
    }

    public override void OnStateEnter()
    {
        bulletSpawner = havanTopcusu.GetComponent<EnemyBulletSpawner>();
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
            BladeProjectiles = new List<GameObject>{havanTopcusu.BlackBullet,havanTopcusu.BlackBullet,havanTopcusu.BlueBullet};
            CodeProjectiles = new List<GameObject>{havanTopcusu.BlackBullet,havanTopcusu.OrangeBullet,havanTopcusu.OrangeBullet};
            for(int i=0;i<3;i++){
                BulletOrder = Random.Range(0,3);
                yield return bulletSpawner.SpawnBullet(BladeProjectiles[BulletOrder],havanTopcusu.BulletPosition.position,havanTopcusu.BulletPosition.rotation,2f);
                BladeProjectiles.RemoveAt(BulletOrder);
                BulletOrder = Random.Range(1,3);
                yield return bulletSpawner.SpawnBullet(CodeProjectiles[BulletOrder],havanTopcusu.BulletPosition.position,havanTopcusu.BulletPosition.rotation,2f);
                CodeProjectiles.RemoveAt(BulletOrder);
            }     
        }
    }

}
