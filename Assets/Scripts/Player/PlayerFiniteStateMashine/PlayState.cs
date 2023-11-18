using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerState: MonoBehaviour
{
    protected Core core;

    protected Player player;
    protected PlayerStateMashine stateMashine;
    protected PlayerData playerData;

    protected bool isAnimationFinished;

    protected bool isExitingState;

    protected float startTime;

    private string animBoolName;


    public PlayerState(Player player, PlayerStateMashine stateMashine, PlayerData playerData, string animBoolName)
    {
        core = player.Core;
        this.player = player;
        this.stateMashine = stateMashine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }
    

    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;


    }

    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
        isExitingState = true;
    }
    public virtual void LogicUpdate()
    {

    }
   

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks() 
    {

    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTriggerForAll()  => isAnimationFinished = true;

}
