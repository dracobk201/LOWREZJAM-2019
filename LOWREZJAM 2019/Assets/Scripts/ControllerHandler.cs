using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerHandler : MonoBehaviour
{
    [SerializeField]
    private BoolReference UIPanelActive;
    [Header("Input Axis")]
    [SerializeField]
    private FloatReference HorizontalAxis;
    [SerializeField]
    private FloatReference VerticalAxis;
    [Header("Input Axis Events")]
    [SerializeField]
    private GameEvent StartButtonEvent;
    [SerializeField]
    private GameEvent NonHorizontalAxisEvent;
    [SerializeField]
    private GameEvent NonVerticalAxisEvent;
    [SerializeField]
    private GameEvent LeftButtonEvent;
    [SerializeField]
    private GameEvent RightButtonEvent;
    [SerializeField]
    private GameEvent UpButtonEvent;
    [SerializeField]
    private GameEvent DownButtonEvent;
    [SerializeField]
    private GameEvent FireButtonEvent;
    [SerializeField]
    private GameEvent JumpButtonEvent;
    [SerializeField]
    private GameEvent UIChangeEvent;

    private bool isStartAxisInUse = false;
    private bool isFireAxisInUse = false;
    private bool isJumpAxisInUse = false;

    private void Update()
    {
        CheckingVerticalAxis();
        CheckingHorizontalAxis();
        CheckingStartButton();
        CheckingFireButton();
        CheckingJumpButton();
    }

    private void CheckingHorizontalAxis()
    {
        if (Input.GetAxisRaw(Global.HorizontalAxis) < 0)
        {
            HorizontalAxis.Value = -1;
            LeftButtonEvent.Raise();
        }
        else if (Input.GetAxisRaw(Global.HorizontalAxis) > 0)
        {
            HorizontalAxis.Value = 1;
            RightButtonEvent.Raise();
        }
        else
        {
            HorizontalAxis.Value = 0;
            NonHorizontalAxisEvent.Raise();
        }
        
    }

    private void CheckingVerticalAxis()
    {
        if (Input.GetAxisRaw(Global.VerticalAxis) < 0)
        {
            VerticalAxis.Value = -1;
            DownButtonEvent.Raise();
            CheckChangeButtonUI();
        }
        else if (Input.GetAxisRaw(Global.VerticalAxis) > 0)
        {
            VerticalAxis.Value = 1;
            UpButtonEvent.Raise();
            CheckChangeButtonUI();
        }
        else
        {
            VerticalAxis.Value = 0;
            NonVerticalAxisEvent.Raise();
        }
    }

    private void CheckingStartButton()
    {
        if (Input.GetAxisRaw(Global.StartAxis) != 0 && !isStartAxisInUse)
        {
            //Debug.Log("Pausé");
            StartButtonEvent.Raise();
            isStartAxisInUse = true;
        }
        else if (Input.GetAxisRaw(Global.StartAxis) == 0)
        {
            isStartAxisInUse = false;
        }
    }

    private void CheckingFireButton()
    {
        if (Input.GetAxisRaw(Global.FireAxis) != 0 && !isFireAxisInUse)
        {
            //Debug.Log("Disparé");
            FireButtonEvent.Raise();
            isFireAxisInUse = true;
        }
        else if (Input.GetAxisRaw(Global.FireAxis) == 0)
        {
            isFireAxisInUse = false;
        }
    }

    private void CheckingJumpButton()
    {
        if (Input.GetAxisRaw(Global.JumpAxis) != 0 && !isJumpAxisInUse)
        {
            //Debug.Log("Salté");
            JumpButtonEvent.Raise();
            isJumpAxisInUse = true;
        }
        else if (Input.GetAxisRaw(Global.JumpAxis) == 0)
        {
            isJumpAxisInUse = false;
        }
    }

    private void CheckChangeButtonUI()
    {
        if (UIPanelActive.Value)
            UIChangeEvent.Raise();
    }
}
