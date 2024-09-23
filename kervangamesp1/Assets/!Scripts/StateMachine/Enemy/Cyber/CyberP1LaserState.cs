using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CyberP1LaserState : CyberState
{
    Cyber Cyber;
    EnemyBulletSpawner BulletSpawner;
    float RandomY;
    int Randomchoice;

    public CyberP1LaserState(Cyber Cyber):base(Cyber){
        this.Cyber = Cyber;
    }

    public override void OnStateEnter(){
        BulletSpawner = cyber.GetComponent<EnemyBulletSpawner>();
        BulletSpawner.StartEnemyCoroutine(ShootLaser());
        
    }
    public override void OnStateUpdate(){
    }
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}

    public IEnumerator ShootLaser(){
        while(true){
        List<Transform> Positions = new List<Transform>{
            cyber.CyberP1LaserPosition1.transform,
            cyber.CyberP1LaserPosition2.transform,
            cyber.CyberP1LaserPosition3.transform,
            cyber.CyberP1LaserPosition4.transform,
            cyber.CyberP1LaserPosition5.transform,
        };

        int orangelaserpos = Random.Range(0,6);
        
        for(int i =0;i<5;i++){
            Transform laserpositions = Positions[i];
            if(i == orangelaserpos){
                GameObject spawnedLaser = GameObject.Instantiate(cyber.CyberOrangeBullet,Positions[i].position,Positions[i].rotation);
                spawnedLaser.transform.SetParent(Positions[i],true);
            }
            else{
                GameObject spawnedLaser = GameObject.Instantiate(cyber.CyberBlueBullet,Positions[i].position,Positions[i].rotation);
                spawnedLaser.transform.SetParent(Positions[i],true);
            }

        }
        yield return new WaitForSeconds(3f);
        }
    }


}

