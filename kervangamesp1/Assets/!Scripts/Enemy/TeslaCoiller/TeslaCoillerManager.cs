using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class TeslaCoillerManager : MonoBehaviour
{
    public List<GameObject> TeslaCoillerList;

    private LineRenderer lineRenderer;
    int i;
    int temp;


    void Start(){
  
    
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

    

        lineRenderer.SetPosition(0,new Vector3(a.transform.position.x,a.transform.position.y,0));
        lineRenderer.SetPosition(1,new Vector3(b.transform.position.x,b.transform.position.y,0));


        

    }

    IEnumerator ElectricityLoop(){
        while(true){
            
            Debug.Log(TeslaCoillerList[i].GetComponent<TeslaCoiller>().ElectricPoint);
            Debug.Log(TeslaCoillerList[i+1].GetComponent<TeslaCoiller>().ElectricPoint);
            
            
            
            StartElectricity(TeslaCoillerList[i].GetComponent<TeslaCoiller>().ElectricPoint,TeslaCoillerList[i+1].GetComponent<TeslaCoiller>().ElectricPoint);
            if(i == TeslaCoillerList.Count-2){        
                i = 0;
            }
            else{
                i+=1;
            }
            yield return new WaitForSeconds(2f);
        }
    }

}
