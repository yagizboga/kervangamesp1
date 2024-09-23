using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{
   public IEnumerator SpawnBullet(GameObject bullet,Vector3 position,Quaternion rotation,float waitseconds){
        Instantiate(bullet,position,rotation);
        yield return new WaitForSeconds(waitseconds);
   }

    public void StartEnemyCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
    public void Spawn(GameObject o,Vector3 position,Quaternion rotation){
        Instantiate(o,position,rotation);

    }

}
