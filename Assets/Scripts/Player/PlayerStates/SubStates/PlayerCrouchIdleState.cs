using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchIdleState : PlayerGroundedState
{
    private bool crouchInput;
    public PlayerCrouchIdleState(Player player, PlayerStateMashine stateMashine, PlayerData playerData, string animBoolName) : base(player, stateMashine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocityZero();
        player.SetColliderHeight(playerData.crouchColliderHeight);
    }

    public override void Exit()
    {
        base.Exit();
        player.SetColliderHeight(playerData.standColliderHeight);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        crouchInput = player.InputHandler.CrouchInput;
        if (!isExitingState)
        {
            if(crouchInput && xInput != 0)
            {
                stateMashine.ChangeState(player.CrouchMoveState);
                Debug.Log("Crouch Move State");
            }
            else if(!crouchInput && !isTouchingCeiling)
            {
                stateMashine.ChangeState(player.IdleState);
            }
        }
    }
}
