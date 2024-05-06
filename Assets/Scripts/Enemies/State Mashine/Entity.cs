using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMashine stateMashine;

    public D_Entity entityData;

   
    public Animator anim { get; private set; }
    
    public AnimationToStateMahine atsm { get; private set; }
    public Core Core { get; private set; }


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



    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        
        currentHealth = entityData.maxhealth;
        currentStunResistence = entityData.stunResistance;

        
        
        atsm = GetComponent<AnimationToStateMahine>();
        anim = GetComponent<Animator>(); 

        

        stateMashine = new FiniteStateMashine();
        
    }
    public virtual void Update()
    {
        stateMashine.currentState.LogicUpdate();
       // anim.SetFloat("yVelocity", core.Movement.RB.velocity.y);

        if(Time.time >= lastDamageTime + entityData.stunRecoveryTime)
        {
            ResetStunResistance();
        }
    }
    public virtual void FixedUpdate()
    {
        stateMashine.currentState.PhysicsUpdate();
        
    }
    
       
    
    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }
    
    public virtual void DamageHop(float velocity)
    {
        velocityWorkspace.Set(Core.Movement.RB.velocity.x, velocity);
        Core.Movement.RB.velocity = velocityWorkspace;
    }
    public virtual void ResetStunResistance()
    {
        isStunned = false;
        currentStunResistence = entityData.stunResistance;
    }
    public virtual void Damage(float ammount )
    {
        lastDamageTime = Time.time;

        currentHealth -= ammount;
        currentStunResistence -= ammount;

        DamageHop(entityData.damageHopSpeed);
        Instantiate(entityData.hitParticles, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        

        if(currentStunResistence <= 0)
        {
            isStunned = true;
        }

        if(currentHealth <= 0)
        {
            isDead = true;
        }
    }

   
}
