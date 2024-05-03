using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleAttackState : AttackState
{
    protected D_MeleAttacState stateData;

    protected AttackDetails attackDetails;

    public MeleAttackState(Entity entity, FiniteStateMashine stateMashine, string animBoolName, Transform attackPosition, D_MeleAttacState stateData) : base(entity, stateMashine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        attackDetails.damageAmmount = stateData.attackDamage;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attactRadious, stateData.whatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            //collider.transform.SendMessage("Damage", attackDetails);

            Debug.Log("Player Hit");
        }
    }
}
