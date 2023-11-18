using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMashine stateMashine, PlayerData playerData, string animBoolName) : base(player, stateMashine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!isExitingState)
        {
            if (xInput != 0)
            {
                stateMashine.ChangeState(player.MoveState);
            }
            else if (isAnimationFinished)
            {
                stateMashine.ChangeState(player.IdleState);
            }
        }
        
    }
}
