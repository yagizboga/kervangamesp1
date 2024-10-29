using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeDroneRidingState : CodeState
{
    public Rigidbody2D droneRb;
    public CodeDroneRidingState(Code code) : base(code)
    {
        droneRb = code._ridableDrone.transform.parent.GetComponent<Rigidbody2D>();
    }

    public override void OnStateEnter()
    {
        Debug.Log("Drone riding entered");
    }

    public override void OnStateExit()
    {
        Debug.Log("Drone riding Exited");
        code._ridableDrone.transform.parent.rotation = Quaternion.Euler(0, 0, 0);
        droneRb.velocity = new Vector2(0, droneRb.velocity.y);
    }

    public override void OnStateFixedUpdate()
    {

    }

    public override void OnStateUpdate()
    {
        HandleDroneMovement();
    }

    private void HandleDroneMovement()
    {
        if (Input.GetKey(code.hackKey) || code._ridableDrone == null) CheckExitStatement();

        if (Input.GetKey(code.moveLeftKey))
        {
            droneRb.velocity = new Vector2(-code.movementSpeed, droneRb.velocity.y);
            code._ridableDrone.transform.parent.rotation = Quaternion.Euler(0, 0, 15);
        }

        else if (Input.GetKey(code.moveRightKey))
        {
            droneRb.velocity = new Vector2(code.movementSpeed, droneRb.velocity.y);
            code._ridableDrone.transform.parent.rotation = Quaternion.Euler(0, 0, -15);
        }

        else
        {
            droneRb.velocity = new Vector2(0, droneRb.velocity.y);
            code._ridableDrone.transform.parent.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void CheckExitStatement()
    {
        code.ChangeState(new CodeIdleState(code));
    }
}
