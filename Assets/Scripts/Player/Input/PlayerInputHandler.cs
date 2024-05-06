using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.Utilities;

 public class PlayerInputHandler : MonoBehaviour 

{
    private PlayerInput playerInput;
                 
    private Camera cam;

    public Vector2 RawMovementInput { get; private set; }

    public Vector2 RawDashDirectionInput { get; private set; }  
    
    
    
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; } 
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; } 
    public bool GrabInput { get; private set; } 
    public bool DashInput { get; private set; }
    public bool DashInputStop { get; private set; }
    public bool CrouchInput { get;private set; }
    public bool[] AttackInputs { get; private set; }
    

    [SerializeField]
    private float inputHoldTime = 0.04f;

    private float JumpInputStartTime;
    private float dashInputStartTime;

    private void Start()
    {

        cam = Camera.main;

        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[count];
        cam = Camera.main;
        playerInput = GetComponent<PlayerInput>();

    }


    private void Update()
    {
       
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();

    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
       {
            AttackInputs[(int)CombatInputs.primary] = true;
            
           
        }
        if (context.canceled)
       {
            AttackInputs[(int)CombatInputs.primary] = false;

           
        }
    } 
    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
   {
        if (context.started)
        {
           AttackInputs[(int)CombatInputs.secondary] = true;
        }
        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }




    //public bool SwitchCurrentControlScheme(params InputDevice[Keyboard] devices);
    //var p2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "KeyboardMouse", Keyboard.current, Mouse.current);

    public void OnCrouchInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            CrouchInput = true;
        }
        else if (context.canceled)
        {
            CrouchInput = false;
        }

    }




    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;  
            JumpInputStartTime = Time.time; 
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
        
    }

    public void OnGrabinput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GrabInput = true;
        }
        if (context.canceled)
        {
            GrabInput = false;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput = true;
            DashInputStop = false;
            dashInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            DashInputStop = true;
        }
    }

    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
       RawDashDirectionInput = context.ReadValue<Vector2>();

        if(playerInput.currentControlScheme == "Keyboard")
        {
       RawDashDirectionInput = cam.ScreenToWorldPoint((Vector3)RawDashDirectionInput) - transform.position;

        }
        

           
       
    }

    public void UseJumpInput() => JumpInput = false;
    
    public void UseDashInput() => DashInput = false;

    private void CheckJumpInputHoldTime()
    {
        if(Time.time >= JumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;  
        }
    }

    private void CheckDashInputHoldTime()
    {
        if(Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }

    
}

public enum CombatInputs
{
    
    primary,
    secondary
}


