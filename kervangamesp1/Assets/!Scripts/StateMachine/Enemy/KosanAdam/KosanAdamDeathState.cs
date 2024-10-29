using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class KosanAdamDeathState : KosanAdamState
{

    public KosanAdamDeathState(KosanAdam KosanAdam):base(KosanAdam){
    }

    public override void OnStateEnter(){
        KosanAdam.BrokenParts.SetActive(true);
        KosanAdam.GetComponent<SpriteRenderer>().enabled = false;
        KosanAdam.StartCoroutine(DeleteParts());
        KosanAdam.StartCoroutine(DisableCollider());
    }
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}

    public IEnumerator DeleteParts(){
        yield return new WaitForSeconds(3f);
        KosanAdam.Destroy(KosanAdam.gameObject);
    }

    public IEnumerator DisableCollider(){
        yield return new WaitForSeconds(0.1f);
        for(int i=0;i<KosanAdam.BrokenParts.transform.childCount;i++){
            KosanAdam.BrokenParts.transform.GetChild(i).GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
