using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GüvenlikSefiShield : GüvenlikSefi
{
    void OnTriggerEnter2D(){
        Debug.Log("Shield collided");
    }
}
