using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class TeslaCoillerManager : MonoBehaviour
{
    public List<GameObject> TeslaCoillerList = new List<GameObject>();
    public List<int> order;

    private LineRenderer lineRenderer;



    void Start(){
        order = new List<int>{};
        for(int i = 0;i<transform.childCount;i++){
            TeslaCoillerList.Add(transform.GetChild(i).GameObject());
        }
        
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;

        StartCoroutine(ElectricityLoop());

        

    }

    void Update(){
    }

    void StartElectricity(GameObject a, GameObject b){
        RaycastHit2D hit = Physics2D.Linecast(a.transform.position,b.transform.position);

        lineRenderer.SetPosition(0,new Vector3(a.transform.position.x,a.transform.position.y,0));
        lineRenderer.SetPosition(1,new Vector3(b.transform.position.x,b.transform.position.y,0));

        if(hit.collider!=null && hit.collider.CompareTag("Blade")||hit.collider.CompareTag("Code")){
            Debug.Log("hit");
        }

        lineRenderer.positionCount = 0;
    }

    IEnumerator ElectricityLoop(){
        while(true){
            for(int i = 0; i<order.Count;i++){
            StartElectricity(TeslaCoillerList[order.IndexOf(i)],TeslaCoillerList[order.IndexOf(i+1)]);
            yield return new WaitForSeconds(2f);
            }
        }
    
    }

}
