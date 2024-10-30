using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class TaretAdamShootingState : TaretAdamState
{
    public TaretAdam TaretAdam;

    int BulletCombinationChoice = 1;
    int current = 0;

    List<GameObject> order1 = new List<GameObject>{};
    List<GameObject> order2 = new List<GameObject>{};
    List<GameObject> order3 = new List<GameObject>{};
    List<GameObject> CurrentOrder;
    public TaretAdamShootingState(TaretAdam TaretAdam):base(TaretAdam){
        this.TaretAdam = TaretAdam;
    }

    public override void OnStateEnter()
    {
        order1 = new List<GameObject>{  taretAdam.BlackBullet,taretAdam.BulletPosition1.gameObject,
                                        taretAdam.OrangeBullet,taretAdam.BulletPosition3.gameObject,
                                        taretAdam.BlueBullet,taretAdam.BulletPosition3.gameObject};

        order2 = new List<GameObject>{  taretAdam.OrangeBullet,taretAdam.BulletPosition1.gameObject,
                                        taretAdam.BlueBullet,taretAdam.BulletPosition2.gameObject,
                                        taretAdam.BlackBullet,taretAdam.BulletPosition3.gameObject};

        order3 = new List<GameObject>{  taretAdam.BlueBullet,taretAdam.BulletPosition2.gameObject,
                                        taretAdam.BlueBullet,taretAdam.BulletPosition2.gameObject,
                                        taretAdam.BlueBullet,taretAdam.BulletPosition2.gameObject,
                                        taretAdam.BlueBullet,taretAdam.BulletPosition2.gameObject,
                                        taretAdam.BlueBullet,taretAdam.BulletPosition2.gameObject};

        CurrentOrder = nextBulletOrder();
    }

    public override void OnStateUpdate()
    {
    
    }

    public override void OnStateFixedUpdate()
    {
        if(current >= CurrentOrder.Count || CurrentOrder[current+1]==null){
            CurrentOrder = nextBulletOrder();
            current =0;
        }

        if(taretAdam.CanShoot){
            //Debug.Log("shoot");
            GameObject.Instantiate(CurrentOrder[current],CurrentOrder[current+1].transform);
            current+=2;
            taretAdam.CanShoot = false;
        }
        if(Mathf.Abs(taretAdam.transform.position.y - CurrentOrder[current+1].transform.position.y) >0.01){
            //Debug.Log("lerp");
            taretAdam.transform.position = new Vector3( taretAdam.transform.position.x,
                                                        Mathf.Lerp(taretAdam.gameObject.transform.position.y,CurrentOrder[current+1].transform.position.y,taretAdam.Speed*Time.deltaTime),
                                                        taretAdam.transform.position.z);
            
        }
        else{
            //Debug.Log("anim");
            if(!taretAdam.isanimstarted){
                taretAdam.GetComponent<Animator>().Play("Base Layer.Shooting",default,0f);
            }
            
        }
        
    }

    public override void OnStateExit()
    {

    }

    List<GameObject> nextBulletOrder(){
        int ranint = Random.Range(1,4);
        if(ranint == 1){
            return order1;
        }
        if(ranint == 2){
            return order2;
        }
        if(ranint == 3){
            return order3;
        }
        return null;
    }
}



