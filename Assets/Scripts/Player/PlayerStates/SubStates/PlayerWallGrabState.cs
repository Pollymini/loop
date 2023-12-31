using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerTouchingWallState
{

    private Vector2 holdPosition;
    public PlayerWallGrabState(Player player, PlayerStateMashine stateMashine, PlayerData playerData, string animBoolName) : base(player, stateMashine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTriggerForAll()
    {
        base.AnimationFinishTriggerForAll();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        holdPosition = player.transform.position;

        HoldPosition();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

       

        if( !isExitingState)
        {
            HoldPosition();

            if (yInput > 0f)
            {
                stateMashine.ChangeState(player.WallClimbState);
            }
            else if (yInput < 0f || !grabInput)
            {
                stateMashine.ChangeState(player.WallSlideState);
            }
        }
        

    }

    private void HoldPosition()
    {
        player.transform.position = holdPosition;

       core.Movement.SetVelocityX(0f);
       core.Movement.SetVelocityY(0f);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
