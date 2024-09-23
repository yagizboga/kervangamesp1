using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CyberP1ProjectileAttackState : CyberState
{
    Cyber Cyber;

    EnemyBulletSpawner BulletSpawner;
    instantiatefunction instantiatefunction;

    public CyberP1ProjectileAttackState(Cyber Cyber):base(Cyber){
        this.Cyber = Cyber;
    }

    public override void OnStateEnter(){
        BulletSpawner = cyber.GetComponent<EnemyBulletSpawner>();
        instantiatefunction =  cyber.AddComponent<instantiatefunction>();
        BulletSpawner.StartEnemyCoroutine(SpawnProjectile());
    }
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}

    public IEnumerator SpawnProjectile(){
        while(true){
        List<Transform> Projectiles = new List<Transform>{cyber.CyberP1ProjectilePosition1.transform,cyber.CyberP1ProjectilePosition2.transform,cyber.CyberP1ProjectilePosition3.transform,cyber.CyberP1ProjectilePosition4.transform,cyber.CyberP1ProjectilePosition5.transform};
        int firstPositionIndex = Random.Range(0,5);
        Transform FirstPosition = Projectiles[firstPositionIndex];

        Projectiles.RemoveAt(firstPositionIndex);

        int secondPositionIndex = Random.Range(0,4);
        Transform SecondPosition = Projectiles[secondPositionIndex];

        instantiatefunction.Spawn(cyber.CyberProjectile,FirstPosition.position,FirstPosition.rotation);
        instantiatefunction.Spawn(cyber.CyberProjectile,SecondPosition.position,SecondPosition.rotation);

        yield return new WaitForSeconds(3f);

        }
    }

}

public class instantiatefunction:MonoBehaviour{
    public void Spawn(GameObject o,Vector3 position,Quaternion rotation){
        Instantiate(o,position,rotation);

    }
}
