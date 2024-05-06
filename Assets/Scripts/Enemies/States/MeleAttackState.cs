using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleAttackState : AttackState
{
    protected D_MeleAttacState stateData;

    

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
       // attackDetails.damageAmmount = stateData.attackDamage;
        core.Movement.SetVelocityX(0f);
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
        core.Movement.SetVelocityX(0f);
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
            IDamagable damagable = collider.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                //damagable.Damage(attackDetails);
                
            }
        }
    }
}
