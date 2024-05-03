using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMashine stateMashine;

    public D_Entity entityData;

    public Rigidbody2D rB { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGo { get; private set; }
    public AnimationToStateMahine atsm { get; private set; }


    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    private Transform groundCheck;



    private float currentHealth;
    private float currentStunResistence;
    private float lastDamageTime;
    public int lastDamageDirection {  get; private set; }   

  

    private Vector2 velocityWorkspace;

    protected bool isStunned;
    protected bool isDead;

    public int facingDirection { get; private set; }

    public virtual void Start()
    {
        facingDirection = 1;
        currentHealth = entityData.maxhealth;
        currentStunResistence = entityData.stunResistance;

        aliveGo = transform.Find("Alive").gameObject;
        rB = aliveGo.GetComponent<Rigidbody2D>();
        atsm = aliveGo.GetComponent<AnimationToStateMahine>();

        
        anim = aliveGo.GetComponent<Animator>(); 

        stateMashine = new FiniteStateMashine();
        
    }
    public virtual void Update()
    {
        stateMashine.currentState.LogicUpdate();

        if(Time.time >= lastDamageTime + entityData.stunRecoveryTime)
        {
            ResetStunResistance();
        }
    }
    public virtual void FixedUpdate()
    {
        stateMashine.currentState.PhysicsUpdate();
        if (rB.velocity != velocityWorkspace)
        {
            rB.velocity = velocityWorkspace;
        }
    }
    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, rB.velocity.y);
        rB.velocity = velocityWorkspace;
    }

    public virtual void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        velocityWorkspace.Set(angle.x * velocity * direction, angle.y * velocity);
        rB.velocity = velocityWorkspace;
    }    
       
    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, aliveGo.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }
    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }
    public virtual bool ChechGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, entityData.groundCheckRadious, entityData.whatIsGround);
    }
    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGo.transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGo.transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGo.transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }
    
    public virtual void DamageHop(float velocity)
    {
        velocityWorkspace.Set(rB.velocity.x, velocity);
        rB.velocity = velocityWorkspace;
    }
    public virtual void ResetStunResistance()
    {
        isStunned = false;
        currentStunResistence = entityData.stunResistance;
    }
    public virtual void Damage(AttackDetails attackDetails)
    {
        lastDamageTime = Time.time;

        currentHealth -= attackDetails.damageAmmount;
        currentStunResistence -= attackDetails.stunDamageAmount;

        DamageHop(entityData.damageHopSpeed);
        Instantiate(entityData.hitParticles, aliveGo.transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        if(attackDetails.position.x > aliveGo.transform.position.x)
        {
            lastDamageDirection = -1;
        }
        else
        {
            lastDamageDirection = 1;
        }

        if(currentStunResistence <= 0)
        {
            isStunned = true;
        }

        if(currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        aliveGo.transform.Rotate(0f, 180f, 0f);
    }
}
