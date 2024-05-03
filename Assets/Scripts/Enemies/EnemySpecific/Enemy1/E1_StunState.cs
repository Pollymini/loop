using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_StunState : StunState
{
    private Enemy1 enemy;
    public E1_StunState(Entity entity, FiniteStateMashine stateMashine, string animBoolName, D_StunState stateData, Enemy1 enemy) : base(entity, stateMashine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isStunTimeOver)
        {
            if (performCloseRangeAction)
            {
                stateMachine.ChangeState(enemy.meleAttackState);
            }
            else if (isplayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.chargeState);
            }
            else
            {
                enemy.lookForPlayerState.SetTurnImmidiately(true);
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }
                

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
