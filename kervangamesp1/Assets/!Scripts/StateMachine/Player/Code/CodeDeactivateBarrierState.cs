using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeDeactivateBarrierState : CodeState
{
    public CodeDeactivateBarrierState(Code code) : base(code)
    {

    }

    public override void OnStateEnter()
    {
        if (GetNearestBarrierObject().activeInHierarchy)
        {
            GetNearestBarrierObject().SetActive(false);
        }
        
        code.ChangeState(new CodeMovingState(code));
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateFixedUpdate()
    {

    }

    public override void OnStateUpdate()
    {

    }

    private GameObject GetNearestBarrierObject()
    {
        GameObject _closestBarrier = null;

        float minDistance = Mathf.Infinity;

        foreach (var barrier in code._barrierList)
        {
            float distance = Vector3.Distance(code.transform.position, barrier.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                _closestBarrier = barrier;
            }
        }

        return _closestBarrier;
    }
}
