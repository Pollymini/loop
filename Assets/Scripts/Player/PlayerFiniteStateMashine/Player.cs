using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using Cinemachine;
using UnityEngine;
using QFSW.QC.Actions;
using QFSW.QC;
using UnityEngine.UI;
using UnityEngine.Networking;
using static UnityEngine.CullingGroup;
using UnityEngine.UIElements.Experimental;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Services.Lobbies.Models;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IDamagable, IKnockbackable 

    
{
   

  
  

    #region State


    public Core Core { get; private set; }
    public PlayerStateMashine StateMashine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }

    public PlayerJumpState JumpState { get; private set; }

    public PlayerInAirState InAirState { get; private set; }

    public PlayerLandState LandState { get; private set; }

    public PlayerWallSlideState WallSlideState { get; private set; }

    public PlayerWallGrabState WallGrabState { get; private set; }

    public PlayerWallClimbState WallClimbState { get; private set; }

    public PlayerWallJumpState WallJumpState { get; private set; }

    public PlayerLedgeClimbState LedgeClimbState { get; private set; }

    public PlayerDashState DashState { get; private set; }

    public PlayerCrouchIdleState CrouchIdleState { get; private set; }

    public PlayerCrouchMoveState CrouchMoveState { get; private set; }

    public PlayerAttackState PrimaryAttackState { get; private set; }

    public PlayerAttackState SecondaryAttackState { get; private set; }
    #endregion

    #region GEMEOBJ
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Transform DashDirectionIndicator { get; private set; }
    public BoxCollider2D MovementCollider { get; private set; }
    public PlayerInventory Inventory { get; private set; }
    #endregion
    
    #region Else
    private SpriteRenderer SR;
            
    public Vector2 CurrentVelocity { get; private set; }


    [SerializeField]
    private PlayerData playerData;

    private Vector2 workspace;
    #endregion






    private void Awake()
    {
       
        Core = GetComponentInChildren<Core>();
        StateMashine = new PlayerStateMashine();

        IdleState = new PlayerIdleState(this, StateMashine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMashine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMashine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMashine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMashine, playerData, "land");
        WallSlideState = new PlayerWallSlideState(this, StateMashine, playerData, "wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMashine, playerData, "wallGrab");
        WallClimbState = new PlayerWallClimbState(this, StateMashine, playerData, "wallClimb");
        WallJumpState = new PlayerWallJumpState(this, StateMashine, playerData, "inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMashine, playerData, "ledgeClimbState");
        DashState = new PlayerDashState(this, StateMashine, playerData, "inAir");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMashine, playerData, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMashine, playerData, "crouchMove");
        PrimaryAttackState = new PlayerAttackState(this, StateMashine, playerData, "attack");
        SecondaryAttackState = new PlayerAttackState(this, StateMashine, playerData, "attack");
    }
    
    private void Start()
    {

        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();

        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();

        DashDirectionIndicator = transform.Find("DashDirectionIndicator");
        MovementCollider = GetComponent<BoxCollider2D>();

        StateMashine.Initialize(IdleState);
       


        Inventory = GetComponent<PlayerInventory>();


        PrimaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.primary]);
        // SecondaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.primary]);
    }
    private void Update()
    {
       
        Core.LogicUpdate();
        StateMashine.CurrentState.LogicUpdate();
    }
    public void Knockback(Vector2 angle, float strength, int direction)
    {
        Core.Movement.SetVelocity(strength, angle, direction);
    }
    public void Damage(float ammount)
    {
        Debug.Log(ammount + "damage");
    }
    private void FixedUpdate()
    {
        StateMashine.CurrentState.PhysicsUpdate();

    }
    public void SetColliderHeight(float height)
    {
        Vector2 center = MovementCollider.offset;
        workspace.Set(MovementCollider.size.x, height);

        center.y += (height - MovementCollider.size.y) / 2;

        MovementCollider.size = workspace;
        MovementCollider.offset = center;
    }
    public Vector2 GetVelocity()
    {
        return RB.velocity;
    }




    #region Flip For Multiplayer 

    /*[ServerRpc]
    void ProvideFlipStateToServerRpc(bool state)
    {
        SR.flipX = state;
        SendFlipStateClientRpc(state);
    }
    [ClientRpc]
    void SendFlipStateClientRpc(bool state)
    {
        if (IsOwner) return;
        SR.flipX = state;

    }*/



    /*public void CheckIfShouldFlip(int xInput)
    {
        
        

        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
       else if (FacingDirection == 1)
        {
            SR.flipX = facingRight;

        }
        else if (FacingDirection != 1)
        {
           SR.flipX = !facingRight;
        }
           // ProvideFlipStateToServerRpc(SR.flipX);
    }

    private void Flip()
    {
         FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
        Debug.Log(FacingDirection + "Direction");
    }*/
    #endregion
  

    private void AnimationTriggerFunction() => StateMashine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMashine.CurrentState.AnimationFinishTriggerForAll();

    
}



















        






   





        

            


        
        














           




    

           
           



        
        
                      

                        
    
    
     
   
    
    

    















   
    

