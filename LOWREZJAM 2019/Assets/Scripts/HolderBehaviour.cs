using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderBehaviour : MonoBehaviour
{
    [SerializeField]
    private FloatReference TimeForWave;
    [SerializeField]
    private FloatReference RemainingTime;
    [SerializeField]
    private FloatReference TargetPercentage;
    private float lastPercentage;

    private void Start()
    {
        lastPercentage = 100;
    }

    private void TimeChecker()
    {
        float actualPercentage = (RemainingTime.Value * 100f) / TimeForWave.Value;
        //Debug.Log(actualPercentage + " - "+ targetPercentage);
        if (actualPercentage <= TargetPercentage.Value)
        {
            //GetComponent<SpriteRenderer>().color = 
            //Mathf.
        }
    }
}
