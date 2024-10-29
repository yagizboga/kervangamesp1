using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
        yield return new WaitForSeconds(1);
        while(true){
            //BladeProjectiles = new List<GameObject>{havanTopcusu.BlackBullet,havanTopcusu.BlackBullet,havanTopcusu.BlueBullet};
            //CodeProjectiles = new List<GameObject>{havanTopcusu.BlackBullet,havanTopcusu.OrangeBullet,havanTopcusu.OrangeBullet};
            for(int i=0;i<3;i++){
                BulletOrder = UnityEngine.Random.Range(0,3-i);
               // BladeProjectiles[BulletOrder].GetComponent<HavanTopcusuBullet>().bladebool = true;
                
                 //   yield return bulletSpawner.SpawnBullet(BladeProjectiles[BulletOrder],havanTopcusu.BulletPosition.position,havanTopcusu.BulletPosition.rotation,2f);
                
              //  BladeProjectiles.RemoveAt(BulletOrder);
               
               
               
                BulletOrder = UnityEngine.Random.Range(0,3-i);
             //   CodeProjectiles[BulletOrder].GetComponent<HavanTopcusuBullet>().bladebool = false;
              //      yield return bulletSpawner.SpawnBullet(CodeProjectiles[BulletOrder],havanTopcusu.BulletPosition.position,havanTopcusu.BulletPosition.rotation,2f);

                
              //  CodeProjectiles.RemoveAt(BulletOrder);

            }     
        }
    }

}
