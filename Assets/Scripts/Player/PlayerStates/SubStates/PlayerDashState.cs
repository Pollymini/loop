using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    private int amountOfDashLeft;


    public bool CanDash { get; private set; }
    private bool isHolding;
    private bool dashInputStop;
    private bool attackInputP;
    private bool attackInputS;


    private float lastDashTime;

    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;
    //private Vector2 lastAIPos;
    public PlayerDashState(Player player, PlayerStateMashine stateMashine, PlayerData playerData, string animBoolName) : base(player, stateMashine, playerData, animBoolName)
    {
        amountOfDashLeft = playerData.amountOfDash;
    }
    public override void Enter()
    {
        base.Enter();

        CanDash = false;

        player.InputHandler.UseDashInput();

        isHolding = true;
        dashDirection = Vector2.right * core.Movement.FacingDirection;

        Time.timeScale = playerData.holdTimeScale;
        startTime = Time.unscaledTime;
                
        player.DashDirectionIndicator.gameObject.SetActive(true);

    }

    public override void Exit()
    {
        base.Exit();
        if(core.Movement.CurrentVelocity.y > 0)
        {
           core.Movement.SetVelocityY(core.Movement.CurrentVelocity.y * playerData.dashEndYMultiplier);
            Time.timeScale = 1f;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        attackInputP = player.InputHandler.AttackInputs[(int)CombatInputs.primary];
        attackInputS = player.InputHandler.AttackInputs[(int)CombatInputs.secondary];

        if (!isExitingState) 
        {

            player.Anim.SetFloat("yVelocity", core.Movement.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(core.Movement.CurrentVelocity.x));
            if(isHolding)
            {
                dashDirectionInput = player.InputHandler.RawDashDirectionInput;
                dashInputStop = player.InputHandler.DashInputStop; 

                if(dashDirectionInput != Vector2.zero)
                {
                    dashDirection = dashDirectionInput;
                    dashDirection.Normalize();
                }

                float angle = Vector2.SignedAngle(Vector2.right, dashDirection);
                player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);

                 if (dashInputStop || Time.unscaledTime >= startTime + playerData.maxHoldTime)
                {
                    isHolding = false;
                    DecreaseAmountOfDashesLeft();
                    Time.timeScale = 0.5f;
                    startTime = Time.time;
                    core.Movement.CheckIfShouldFlip(Mathf.RoundToInt(dashDirection.x));
                    player.RB.drag = playerData.drag;
                    core.Movement.SetVelocity(playerData.dashVelocity, dashDirection);
                    player.DashDirectionIndicator.gameObject.SetActive(false);
                    // PlaceAfterImage();

                   
                }
            }
            else
            {
               core.Movement.SetVelocity(playerData.dashVelocity, dashDirection);
                
                //CheckIfShouldPlaceAfterImage();

                if (Time.time >= startTime + playerData.dashTime)
                {
                    DecreaseAmountOfDashesLeft();
                    if (attackInputP)
                    {

                        stateMashine.ChangeState(player.PrimaryAttackState);
                    }
                    else if (attackInputS)
                    {
                        stateMashine.ChangeState(player.SecondaryAttackState);
                    }
                    player.RB.drag = 0f;
                    isAbilityDone = true;
                    lastDashTime = Time.time;
                    Time.timeScale = 1f;
                    

                }
            }
        }
    }
    public bool CheckIfCanDash()
    {
        
        if ( amountOfDashLeft > 0)
        {
          return CanDash = true && Time.time >= lastDashTime + playerData.dashCoolDown;

        }
        else
        {
          return CanDash = false;
        }
            
        
    }

    public void ResetAmountOfDashesLeft()
    {         
         amountOfDashLeft = playerData.amountOfDash;
        
    } 




    public void DecreaseAmountOfDashesLeft() => amountOfDashLeft--;
   



  


   
   // private void PlaceAfterImage()
   // {
    //    PlayerAfterImagePool.Instance.GetFromPool();
    //    lastAIPos = player.transform.position;
   // }

    
}

// private void CheckIfShouldPlaceAfterImage()
//{
  //  if (Vector2.Distance(player.transform.position, lastAIPos) >= playerData.distBetweenAfterImages)
 //   {
 //       PlaceAfterImage();
 //   }
//}