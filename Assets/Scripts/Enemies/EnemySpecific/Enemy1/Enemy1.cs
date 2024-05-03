using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{

    public Rigidbody2D rb;
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }   
    public E1_ChargeState chargeState { get; private set; }
    public E1_PlayerDetectedState playerDetectedState { get; private set; }
    public E1_MeleAttackState meleAttackState { get; private set; }
    public E1_StunState stunState { get; private set; } 
    public E1_DeadState deadState { get; private set; }


    [SerializeField]
    private D_idleState idleStateData;
    [SerializeField] 
    private D_moveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    private D_MeleAttacState meleAttacStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    [SerializeField]
    private Transform meleAttackPosition;
    public override void Start()
    {
        base.Start();

        moveState = new E1_MoveState(this, stateMashine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMashine, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetectedState(this, stateMashine, "playerDetected", playerDetectedData, this);
        chargeState = new E1_ChargeState(this, stateMashine, "charge", chargeStateData, this);
        lookForPlayerState = new E1_LookForPlayerState(this, stateMashine, "lookForPlayer", lookForPlayerStateData, this);
        meleAttackState = new E1_MeleAttackState(this, stateMashine,"meleAttack", meleAttackPosition, meleAttacStateData, this);
        stunState = new E1_StunState(this, stateMashine, "stun", stunStateData, this);  
        deadState = new E1_DeadState(this, stateMashine,"dead", deadStateData, this);
        stateMashine.Initialize(moveState);

        rb = GetComponentInChildren<Rigidbody2D>();
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
        if (isDead)
        {
            stateMashine.ChangeState(deadState);
        }
        else if (isStunned && stateMashine.currentState != stunState)
        {
            stateMashine.ChangeState(stunState);
        }
        
    }
}
