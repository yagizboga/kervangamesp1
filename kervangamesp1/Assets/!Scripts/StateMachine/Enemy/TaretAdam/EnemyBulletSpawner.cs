using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{
   public IEnumerator SpawnBullet(GameObject bullet,Transform posrot,float waitseconds){
        Instantiate(bullet,posrot.position,posrot.rotation);
        yield return new WaitForSeconds(waitseconds);
   }

    public void StartShootingCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

}
