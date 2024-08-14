using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretAdamBulletSpawner : MonoBehaviour
{
   public IEnumerator SpawnBullet(GameObject bullet,Transform posrot){
        Instantiate(bullet,posrot.position,posrot.rotation);
        yield return new WaitForSeconds(1.5f);
   }

    public void StartShootingCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

}
