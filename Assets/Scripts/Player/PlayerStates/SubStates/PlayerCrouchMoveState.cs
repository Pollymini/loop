using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchMoveState : PlayerGroundedState
{
    private bool crouchInput;
    public PlayerCrouchMoveState(Player player, PlayerStateMashine stateMashine, PlayerData playerData, string animBoolName) : base(player, stateMashine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
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
           core.Movement.SetVelocityX(playerData.CrouchMovementVelocity * core.Movement.FacingDirection);
           core.Movement.CheckIfShouldFlip(xInput);

            if(crouchInput && xInput == 0)
            {
                stateMashine.ChangeState(player.CrouchIdleState);
                Debug.Log("Crouch Idle State");
            }
            else if (!crouchInput && !isTouchingCeiling)
            {
                stateMashine.ChangeState(player.MoveState);
                
            }
            
        }
    }
}
