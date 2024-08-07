using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;

    void Update()
    {
        playerRigidBody.velocity = new Vector2(0,0);
        if(Input.GetKey("a")){
            playerRigidBody.velocity = new Vector2(-20,0);
        }
        if(Input.GetKey("d")){
            playerRigidBody.velocity = new Vector2(20,0);
        }
    }
}
