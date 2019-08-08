using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayBehaviour : MonoBehaviour
{
    [SerializeField]
    private FloatReference TimeForWave;
    [SerializeField]
    private FloatReference RemainingTime;
    [SerializeField]
    private FloatReference InitialPercentage;
    [SerializeField]
    private FloatReference StepPercentage;
    [SerializeField]
    private FloatReference TargetPercentage;
    [SerializeField]
    private GameEvent TimeToNewWave;

    private void Start()
    {
        RemainingTime.Value = TimeForWave.Value;
        TargetPercentage.Value = InitialPercentage.Value;
    }

    private void Update()
    {
        RemainingTime.Value -= Time.deltaTime;
        TimeChecker();
    }

    private void TimeChecker()
    {
        float actualPercentage = (RemainingTime.Value * 100f) / TimeForWave.Value;
        //Debug.Log(actualPercentage + " - "+ targetPercentage);
        if (actualPercentage <= TargetPercentage.Value)
        {
            TimeToNewWave.Raise();
            TargetPercentage.Value /= StepPercentage.Value;
        }
    }
}
