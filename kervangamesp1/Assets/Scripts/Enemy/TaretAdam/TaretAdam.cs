using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretAdam : Enemy
{

   TaretAdamAwakeState taretAdamAwakeState;
   void Awake(){
      taretAdamAwakeState = new TaretAdamAwakeState(this);

      CurrentState = taretAdamAwakeState;
   }
}
