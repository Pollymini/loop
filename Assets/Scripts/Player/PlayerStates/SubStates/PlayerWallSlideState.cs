using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    public PlayerWallSlideState(Player player, PlayerStateMashine stateMashine, PlayerData playerData, string animBoolName) : base(player, stateMashine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isExitingState)
        {
           core.Movement.SetVelocityY(-playerData.wallSlideVelocity);

            if (grabInput && yInput == 0) 
            {
                stateMashine.ChangeState(player.WallGrabState);
            }
        }
       
    }
}
