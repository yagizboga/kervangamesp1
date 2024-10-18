using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BladeComboManager : MonoBehaviour
{
    Blade blade;
    private float timer = 0;
    private bool isComboStart = false;
    public static BladeComboManager Instance;
    public bool comboMaintain = false;

    private void Awake()
    {
        Instance = this;
        blade = GetComponent<Blade>();
    }

    public void StartBladeComboTimer()
    {
        if (blade.currentComboNumber < 3)
        {
            blade.currentComboNumber++;
            timer = 0;
        }

        isComboStart = true;
    }

    public void StopBladeComboTimer()
    {
        blade.currentComboNumber = 1;
        isComboStart = false;
        timer = 0;
    }

    void Update()
    {
        if (isComboStart)
        {
            if (timer <= blade.comboTimer)
            {
                timer += Time.deltaTime;
            }

            if (timer >= blade.comboTimer)
            {
                blade.currentComboNumber = 1;
                timer = 0;
                isComboStart = false;
            }
        }
    }
}
