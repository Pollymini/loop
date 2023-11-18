using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    private bool crouchInput;
    public PlayerMoveState(Player player, PlayerStateMashine stateMashine, PlayerData playerData, string animBoolName) : base(player, stateMashine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        crouchInput = player.InputHandler.CrouchInput;

       
        player.GetVelocity();
        
      


        if (!isExitingState)
            core.Movement.SetVelocityX(playerData.movementVelocity * xInput);
            core.Movement.CheckIfShouldFlip(xInput);
        {
            if (xInput == 0 && !isExitingState)
            {
                stateMashine.ChangeState(player.IdleState);
            }
            else if (crouchInput && xInput != 0)
            {
                stateMashine.ChangeState(player.CrouchMoveState);
            }
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
