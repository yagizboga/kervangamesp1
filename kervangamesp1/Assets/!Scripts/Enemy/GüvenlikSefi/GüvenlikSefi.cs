using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GüvenlikSefi : StateMachine
{
    /*awakeState
    faz1state
    faz2state
    faz3state
    deathstate

    can olcak 
    shield body ve sword collider

    */

    public float GüvenlikSefiHealth = 100;

    GüvenlikSefiAwakeState awakeState;

    void Awake(){
        awakeState = new GüvenlikSefiAwakeState(this);
    }

    void Start(){
        ChangeState(awakeState);
    }


    public void GüvenlikSefiBodyCollide(){}
    public void GüvenlikSefiSwordCollide(){}
    public void GüvenlikSefiShieldCollide(){}
    

}
