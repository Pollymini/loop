using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{

    private int amountOfJumpsLeft;
    


    public PlayerJumpState(Player player, PlayerStateMashine stateMashine, PlayerData playerData, string animBoolName) : base(player, stateMashine, playerData, animBoolName)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

   

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UseJumpInput();
        core.Movement.SetVelocityY(playerData.jumpVelocity);
        isAbilityDone = true;
        amountOfJumpsLeft--;
        player.InAirState.SetIsJumping();
        player.DashState.ResetAmountOfDashesLeft();

    }
    public bool CanJump()
    {
        if(amountOfJumpsLeft > 0)
        {
          return true;
        }
        else
        {
           return false;   
        }
    }
    

    public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = playerData.amountOfJumps;

    public void DecreseAmountOfJumpsLeft() => amountOfJumpsLeft--;
}
