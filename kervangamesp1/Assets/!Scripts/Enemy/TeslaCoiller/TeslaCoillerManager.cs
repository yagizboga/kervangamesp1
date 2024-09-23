using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaCoillerManager : MonoBehaviour
{
    public List<TeslaCoiller> TeslaCoillerList = new List<TeslaCoiller>();

    void Start(){
        StartCoroutine(StartTeslaCoillerElectricity());
    }

    void Update(){
    }

    public IEnumerator StartTeslaCoillerElectricity(){
        while(true){
        TeslaCoillerList[1].GetComponent<BoxCollider2D>().enabled = false;
        TeslaCoillerList[0].GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(4f);
        TeslaCoillerList[0].GetComponent<BoxCollider2D>().enabled = false;
        TeslaCoillerList[1].GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(4f);
    }
    }
}
