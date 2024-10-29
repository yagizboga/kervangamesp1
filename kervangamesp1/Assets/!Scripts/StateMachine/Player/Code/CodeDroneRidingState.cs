using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


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
        code.transform.SetParent(code._ridableDrone.transform, true);
        code._ridableDrone.transform.parent.GetComponent<DroneShootingState>().OnStateExit();
    }

    public override void OnStateExit()
    {
        Debug.Log("Drone riding Exited");
        code._ridableDrone.transform.parent.DORotate(new Vector3(0, 0, 0), 0);
        code.transform.DORotate(new Vector3(0, 0, 0), 0);
        code.transform.SetParent(code.playerParent.transform, true);  
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

        Vector3 currentPosition = code._ridableDrone.transform.parent.position;

        if (Input.GetKey(code.jumpKey))
        {
            currentPosition.y += code.movementSpeed * Time.deltaTime;
            code._ridableDrone.transform.parent.position = currentPosition;
        }

        if (Input.GetKey(code.crouchKey))
        {
            currentPosition.y -= code.movementSpeed * Time.deltaTime;
            code._ridableDrone.transform.parent.position = currentPosition;
        }

        if (Input.GetKey(code.moveLeftKey))
        {
            currentPosition.x -= code.movementSpeed * Time.deltaTime;
            code._ridableDrone.transform.parent.position = currentPosition;
            code._ridableDrone.transform.parent.DORotate(new Vector3(0, 0, 15), 0.5f);
            code.spriteRenderer.flipX = true;
        }

        else if (Input.GetKey(code.moveRightKey))
        {
            currentPosition.x += code.movementSpeed * Time.deltaTime;
            code._ridableDrone.transform.parent.position = currentPosition;
            code._ridableDrone.transform.parent.DORotate(new Vector3(0, 0, -15), 0.5f);
            code.spriteRenderer.flipX = false;
        }

        else
        {
            code._ridableDrone.transform.parent.DORotate(new Vector3(0, 0, 0), 0.5f);
        }
    }

    private void CheckExitStatement()
    {
        code.ChangeState(new CodeIdleState(code));
    }
}
