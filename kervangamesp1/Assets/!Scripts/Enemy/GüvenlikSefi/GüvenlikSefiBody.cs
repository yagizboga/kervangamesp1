using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GüvenlikSefiBody : MonoBehaviour
{
    void OnTriggerEnter2D(){
        Debug.Log("body collided");
    }
}
