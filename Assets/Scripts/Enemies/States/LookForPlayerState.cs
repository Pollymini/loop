using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : State
{
    protected D_LookForPlayerState stateData;

    protected bool turnImmidiately;

    protected bool isPlayerInMinAgrorange;
    protected bool isAllTurnsDone;
    protected bool isAllTurnsTimeDone;

    protected float lastTurnTime;

    protected int ammountOfTurnsDone;
    public LookForPlayerState(Entity entity, FiniteStateMashine stateMashine, string animBoolName, D_LookForPlayerState stateData) : base(entity, stateMashine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgrorange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;

        lastTurnTime = startTime;
        ammountOfTurnsDone = 0;

        entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(turnImmidiately == true)
        {
            entity.Flip();
            lastTurnTime = Time.time;
            ammountOfTurnsDone++;
            turnImmidiately = false;
        }
        else if(Time.time > lastTurnTime + stateData.timeBetweenTurns && !isAllTurnsDone)
        {
            entity.Flip();
            lastTurnTime = Time.time;
            ammountOfTurnsDone++;
        }

        if(ammountOfTurnsDone > stateData.ammountOfTurns)
        {
            isAllTurnsDone = true;
        }

        if(Time.time >= lastTurnTime + stateData.timeBetweenTurns && isAllTurnsDone)
        {
            isAllTurnsTimeDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetTurnImmidiately(bool flip)
    {
        turnImmidiately = flip;
    }
}
