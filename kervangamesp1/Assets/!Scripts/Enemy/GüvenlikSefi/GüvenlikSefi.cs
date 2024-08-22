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
    public Collider2D GüvenlikSefiSword;
    public Collider2D GüvenlikSefiShield;

    GüvenlikSefiAwakeState awakeState;
    GüvenlikSefiPhase1State phase1State;
    GüvenlikSefiPhase2State phase2State;
    GüvenlikSefiPhase3State phase3State;
    GüvenlikSefiDeathState deathState;



    void Awake(){
        awakeState = new GüvenlikSefiAwakeState(this);
        phase1State = new GüvenlikSefiPhase1State(this);
        phase2State = new GüvenlikSefiPhase2State(this);
        phase3State = new GüvenlikSefiPhase3State(this);
        deathState = new GüvenlikSefiDeathState(this);
        GüvenlikSefiSword.enabled = false;
        GüvenlikSefiShield.enabled = false;
    }

    void Start(){
        ChangeState(awakeState);
    }

    void Update(){
        if(GüvenlikSefiHealth >70 && CurrentState != phase1State){
            ChangeState(phase1State);
        }
        else if(GüvenlikSefiHealth <=70 && GüvenlikSefiHealth > 30 && CurrentState !=phase2State){
            ChangeState(phase2State);
        }
        else if(GüvenlikSefiHealth <=30 && GüvenlikSefiHealth >0 && CurrentState != phase3State){
            ChangeState(phase3State);
        }
        else if(GüvenlikSefiHealth <=0 && CurrentState != deathState){
            ChangeState(deathState);
        }
    }

    public void SwordAttack(){
        GüvenlikSefiSword.enabled = true;
        Debug.Log("swordAttack");
    }
    public void ShieldAttack(){
        Debug.Log("shieldAttack");
    }


    

}
