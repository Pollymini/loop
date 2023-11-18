using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    private bool crouchInput;
    public PlayerIdleState(Player player, PlayerStateMashine stateMashine, PlayerData playerData, string animBoolName) : base(player, stateMashine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
       core.Movement.SetVelocityX(0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        crouchInput = player.InputHandler.CrouchInput;
        if (!isExitingState)
        {
            if (xInput != 0)
            {
                stateMashine.ChangeState(player.MoveState);
            }
            else if (crouchInput && xInput == 0)
            {
                stateMashine.ChangeState(player.CrouchIdleState);
            }
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
