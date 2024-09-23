using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberP3ArmAttackState : CyberState
{
   
    Cyber Cyber;
    EnemyBulletSpawner BulletSpawner;
    public CyberP3ArmAttackState(Cyber Cyber):base(Cyber){
        this.cyber = Cyber;
    }

    public override void OnStateEnter(){

        ArmAttack();
        BulletSpawner = cyber.GetComponent<EnemyBulletSpawner>();
        BulletSpawner.StartEnemyCoroutine(BulletSpawner.SpawnBullet(cyber.CyberBlackBullet,cyber.transform.position,cyber.transform.rotation,3));
    }
    public override void OnStateUpdate(){
    }
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}

    public void ArmAttack(){
        Debug.Log("armAttack");

    }



}
