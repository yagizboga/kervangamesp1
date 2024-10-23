using System.Collections;
using UnityEngine;

public class KosanAdamShootingState : KosanAdamState
{
    private KosanAdam kosanAdam;
    private float shootInterval = 2f; 
    private bool isShooting = false;

    public KosanAdamShootingState(KosanAdam kosanAdam) : base(kosanAdam)
    {
        this.kosanAdam = kosanAdam;
    }

    public override void OnStateEnter()
    {
        Debug.Log("Kosan Adam Shooting State");
        if (!isShooting)
        {
            kosanAdam.StartCoroutine(Shooting());
        }
    }

    public override void OnStateUpdate()
    {
       
        MoveTowardsBlade();
    }

    public override void OnStateExit()
    {
        isShooting = false;
        kosanAdam.StopCoroutine(Shooting());
    }

    private void MoveTowardsBlade()
    {
       
        GameObject blade = GameObject.FindWithTag("Blade");
        Debug.Log(blade);
        if (blade != null)
        {
            Vector2 direction = (blade.transform.position - kosanAdam.transform.position).normalized;
            kosanAdam.rb.velocity = new Vector3(direction.x,0,0) * 4f;
        }
    }

    private IEnumerator Shooting()
    {
        isShooting = true;
        while (isShooting)
        {
           
            FireBlueBullet();
            yield return new WaitForSeconds(shootInterval);
        }
    }

    private void FireBlueBullet()
    {
    
        GameObject blade = GameObject.FindWithTag("Blade");

        if (blade != null)
        {
            Vector2 direction = (blade.transform.position - kosanAdam.transform.position).normalized;
            GameObject bullet = GameObject.Instantiate(kosanAdam.BlueBullet, kosanAdam.SpawnPoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 5f; 
        }
    }
}
