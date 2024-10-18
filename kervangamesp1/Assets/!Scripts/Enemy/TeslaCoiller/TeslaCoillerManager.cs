using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class TeslaCoillerManager : MonoBehaviour
{
    public List<GameObject> TeslaCoillerList = new List<GameObject>();
    public List<TeslaCoiller> TeslaCoillerOrder = new List<TeslaCoiller>();

    private LineRenderer lineRenderer;
    int i=0;
    int temp;


    void Start(){
        for(int i = 0;i<transform.childCount;i++){
            TeslaCoillerList.Add(transform.GetChild(i).gameObject);
        }

        foreach(var teslaCoiller in TeslaCoillerList){
            TeslaCoillerOrder.Add(teslaCoiller.GetComponent<TeslaCoiller>());
            for(int i = 0;i<TeslaCoillerOrder.Count;i++){
                 if(teslaCoiller.GetComponent<TeslaCoiller>().id < TeslaCoillerOrder[i].id){
                    temp = TeslaCoillerList[i].GetComponent<TeslaCoiller>().id;
                    TeslaCoillerList[i].GetComponent<TeslaCoiller>().id = teslaCoiller.GetComponent<TeslaCoiller>().id;
                    teslaCoiller.GetComponent<TeslaCoiller>().id =temp;
                 } 
            }


        }   
        
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;

        StartCoroutine(ElectricityLoop());

        

    }

    void Update(){
        Debug.Log(i);
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
            StartElectricity(TeslaCoillerOrder[i].gameObject.transform.GetChild(0).gameObject,TeslaCoillerOrder[i+1].gameObject.transform.GetChild(0).gameObject);
            yield return new WaitForSeconds(2f);
            if(i==TeslaCoillerList.Count-1){
                i=0;
            }
            i++;
        }
    }

}
