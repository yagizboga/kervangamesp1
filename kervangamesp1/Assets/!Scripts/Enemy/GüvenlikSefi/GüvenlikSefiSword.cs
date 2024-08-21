using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GüvenlikSefiSword : GüvenlikSefi
{
    void OnTriggerEnter2D(){
        Debug.Log("Sword collided");
    }
}
