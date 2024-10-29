using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgirKalkanDeathState : AgirKalkanState
{
    public AgirKalkan AgirKalkan;
    public AgirKalkanDeathState(AgirKalkan AgirKalkan):base(AgirKalkan){
        this.AgirKalkan = AgirKalkan;
    }

    public override void OnStateEnter(){
        agirKalkan.BrokenParts.SetActive(true);
        agirKalkan.GetComponent<SpriteRenderer>().enabled = false;
        agirKalkan.StartCoroutine(DeleteParts());
        agirKalkan.StartCoroutine(DisableCollider());
    }
    public override void OnStateUpdate(){}
    public override void OnStateFixedUpdate(){}
    public override void OnStateExit(){}

    public IEnumerator DeleteParts(){
        yield return new WaitForSeconds(3f);
        KosanAdam.Destroy(agirKalkan.gameObject);
    }

    public IEnumerator DisableCollider(){
        yield return new WaitForSeconds(0.1f);
        for(int i=0;i<agirKalkan.BrokenParts.transform.childCount;i++){
            agirKalkan.BrokenParts.transform.GetChild(i).GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

}
