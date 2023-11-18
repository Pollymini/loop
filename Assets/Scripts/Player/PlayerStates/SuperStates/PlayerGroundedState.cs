using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected int yInput;

    protected bool isTouchingCeiling;
    private bool crouchInput;
    private bool JumpInput;
    private bool grabInput;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingLedge;
    private bool dashInput;
    private bool NearEnemy;
    private bool attackInput;

    public PlayerGroundedState(Player player, PlayerStateMashine stateMashine, PlayerData playerData, string animBoolName) : base(player, stateMashine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
       
        isGrounded = core.CollisionSenses.Ground;
        isTouchingWall = core.CollisionSenses.WallFront;
        isTouchingLedge = core.CollisionSenses.Ledge;
        isTouchingCeiling = core.CollisionSenses.Ceiling;
    }

    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpsLeft();
        player.DashState.ResetAmountOfDashesLeft();
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;    
        JumpInput = player.InputHandler.JumpInput;
        grabInput = player.InputHandler.GrabInput;
        dashInput = player.InputHandler.DashInput;
        crouchInput = player.InputHandler.CrouchInput;
        




      if (player.InputHandler.AttackInputs[(int)CombatInputs.primary] && !isTouchingCeiling)
      {
           stateMashine.ChangeState(player.PrimaryAttackState);
      }
      else if (player.InputHandler.AttackInputs[(int)CombatInputs.secondary] && !isTouchingCeiling)
      { 
            stateMashine.ChangeState(player.SecondaryAttackState);
      }
      else if (JumpInput && player.JumpState.CanJump()) 
      {
          stateMashine.ChangeState(player.JumpState);  
      }
      else if(!isGrounded)
      {
            player.InAirState.StartCoyoteTime();
            stateMashine.ChangeState(player.InAirState);
      }
      else if(isTouchingWall && grabInput && isTouchingLedge)
      {
            stateMashine.ChangeState(player.WallGrabState);
      }
      else if (dashInput && player.DashState.CheckIfCanDash() && !isTouchingCeiling)
      {
            stateMashine.ChangeState(player.DashState);
           
      }
      else if (crouchInput && xInput == 0)
        {
            stateMashine.ChangeState(player.CrouchIdleState);
            Debug.Log(" In Grounded Crouch Idle State");
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
