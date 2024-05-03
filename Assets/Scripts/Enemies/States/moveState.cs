using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveState : State
{
    protected D_moveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;

    protected bool isPlayerInMinAgroRange;
    public moveState(Entity entity, FiniteStateMashine stateMashine, string animBoolName, D_moveState stateData) : base(entity, stateMashine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();

    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.movementSpeed);

    }
       

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        entity.SetVelocity(stateData.movementSpeed);

    }
        
}
