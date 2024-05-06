using Mono.CSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;

    private bool dashInput;

    private int xInput;

    private float velocityToSet;

    private bool setVelocity;


    private bool shouldCheckFlip;


    public PlayerAttackState(Player player, PlayerStateMashine stateMashine, PlayerData playerData, string animBoolName) : base(player, stateMashine, playerData, animBoolName)
    {
       
    }
    private void Awake()
    {
       

    }
    private void Update()
    {
        
    }

    public override void Enter()
    {
       
        base.Enter();
        setVelocity = false;
        weapon.EnterWeapon();
        player.DashState.ResetAmountOfDashesLeft();

    }

    public override void LogicUpdate()
    {
       
        base.LogicUpdate();
        xInput = player.InputHandler.NormInputX;
        dashInput = player.InputHandler.DashInput;
        if (shouldCheckFlip)
        {
            core.Movement.CheckIfShouldFlip(xInput);

        }
        if (dashInput)
        {

            stateMashine.ChangeState(player.DashState);
        }

        else if (setVelocity)
        {
         core.Movement.SetVelocityX(velocityToSet * core.Movement.FacingDirection);
         

            if (core.CollisionSenses.Ground == false)
            {
                
                {
                    

                    core.Movement.SetVelocityX(0f);
                    core.Movement.SetVelocityY(0f);
                }

            }

        }
        
    }

    public override void Exit()
    { 
        base.Exit();
       
        weapon.ExitWeapon();
        
    }
    public void SetWeapon(Weapon weapon)

    {
        this.weapon = weapon;
        this.weapon.InitializeWeapon(this, core);
    }
    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }
    public void SetPlayerVelocity(float velocity)
    {
       core.Movement.SetVelocityX(velocity * core.Movement.FacingDirection);
       core.Movement.SetVelocityY(velocity * core.Movement.FacingDirection);

        velocityToSet   = velocity;
        setVelocity = true;
    }

    #region Animation Triggers
    public override void AnimationFinishTriggerForAll()
    {
        base.AnimationFinishTriggerForAll();

        isAbilityDone = true;
    }

    #endregion
}

