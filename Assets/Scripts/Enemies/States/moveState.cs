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
        if(core.Movement != null)
        {
          isDetectingLedge = core.CollisionSenses.LedgeVertical;
            isDetectingWall = core.CollisionSenses.WallFront;
            isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();

        }
        else
        {
            Debug.Log("Collisions senses is null");
        }

    }

    public override void Enter()
    {
        base.Enter();
        if(core.Movement != null)
        {
            core.Movement.SetVelocityX(stateData.movementSpeed * core.Movement.FacingDirection);

        }
        else
        {
            Debug.Log("No Core");
        }

    }
       

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        core.Movement.SetVelocityX(stateData.movementSpeed * core.Movement.FacingDirection);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

       

    }
        
}
