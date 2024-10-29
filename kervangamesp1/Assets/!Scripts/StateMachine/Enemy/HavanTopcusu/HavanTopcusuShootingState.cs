using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HavanTopcusuShootingState : HavanTopcusuState
{
    public HavanTopcusu Havantopcusu;



    List<GameObject> BladeProjectiles = new List<GameObject>{};
    List<GameObject> CodeProjectiles = new List<GameObject>{};
    int randomint;

    

    public HavanTopcusuShootingState(HavanTopcusu Havantopcusu):base(Havantopcusu){
        this.Havantopcusu = Havantopcusu;
    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateFixedUpdate()
    {


        if(BladeProjectiles.Count == 0){
            BladeProjectiles = new List<GameObject>{havanTopcusu.BlackBullet,havanTopcusu.BlackBullet,havanTopcusu.BlueBullet};
        }
        if(CodeProjectiles.Count == 0){
            CodeProjectiles = new List<GameObject>{havanTopcusu.BlackBullet,havanTopcusu.OrangeBullet,havanTopcusu.OrangeBullet};
        }
        if(havanTopcusu.canShootBlade || havanTopcusu.canShootCode){
            GameObject.Instantiate(NextBullet(),havanTopcusu.BulletPosition.position,havanTopcusu.BulletPosition.rotation);
            havanTopcusu.canShootBlade = false;
            havanTopcusu.canShootCode = false;
        }

    }

    public override void OnStateUpdate()
    {
    }

    public override void OnStateExit()
    {

    }

    GameObject NextBullet(){
        randomint = UnityEngine.Random.Range(0,3);
        if(havanTopcusu.canShootBlade){
            BladeProjectiles[randomint].GetComponent<HavanTopcusuBullet>().bladebool = true;
            return BladeProjectiles[randomint];

        }
        if(havanTopcusu.canShootCode){
            CodeProjectiles[randomint].GetComponent<HavanTopcusuBullet>().bladebool = false;
            return CodeProjectiles[randomint];
        }
        return null;
    }

}
