using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeExecutionState : BladeState
{
    public float executionTimer = 3f;

    private KeyCode currentKey;
    private List<KeyCode> keyList = new List<KeyCode> { KeyCode.H, KeyCode.J, KeyCode.K };
    private bool isKeyCorrect = false;
    public BladeExecutionState(Blade blade) : base(blade)
    {

    }

    public override void OnStateEnter()
    {
        SetNewKey();
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateFixedUpdate()
    {

    }

    public override void OnStateUpdate()
    {
        CountDown();
        CheckCorrectKeyPressed();
    }

    private void CheckCorrectKeyPressed()
    {
        if (isKeyCorrect) return;

        if (Input.GetKeyDown(currentKey))
        {
            Debug.Log("Correct Key Pressed!");
            isKeyCorrect = true;
            SetNewKey();
        }
    }

    private void SetNewKey()
    {
        currentKey = keyList[Random.Range(0, keyList.Count)];
        isKeyCorrect = false;
        Debug.Log("Execution skill's current key is: " + currentKey);
    }

    private void CountDown()
    {
        if (executionTimer <= 0)
        {
            blade.bossCamera.Priority = 1;
            blade.ChangeState(new BladeMovingState(blade));
        }

        executionTimer -= Time.deltaTime;
    }
}
