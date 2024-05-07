using Mono.CSharp;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class Weapon : MonoBehaviour

{
    [SerializeField] protected SO_WeaponData weaponData;

    protected Player player;

    protected Core core;

    protected PlayerDashState dashState;

   

    private Animator baseAnimator;
 
    private Animator weaponAnimator;

    protected PlayerAttackState state;

    protected int attackCounter;

   


    
    



    #region Spawn Start Enter Exit



    protected virtual void Awake()
    {
       core = GetComponent<Core>();

       baseAnimator = transform.Find("Base").GetComponent<Animator>();
       weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

       gameObject.SetActive(false);

    }
        

        
   

      



    #endregion


    public virtual void EnterWeapon()
    {
       gameObject.SetActive(true);
        
        if(attackCounter >= weaponData.amountOfAttacks)
        {
            attackCounter = 0;

        }

        

       

        

        baseAnimator.SetBool("attack", true);
        weaponAnimator.SetBool("attack", true);

        baseAnimator.SetInteger("attackCounter", attackCounter);
        weaponAnimator.SetInteger("attackCounter", attackCounter);
       
        
      
    }

    public virtual void ExitWeapon()
    {
        baseAnimator.SetBool("attack", false);
       
        weaponAnimator.SetBool("attack", false);

        attackCounter++;

       

        gameObject.SetActive(false);
        
    }
   
    #region Animation Triggers

    public virtual void AnimationFinishTriggerForAll()
    {
        state.AnimationFinishTriggerForAll();
    }

     public virtual void AnimationStartMovementTrigger()
     {
         state.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
     }
     public virtual void AnimationStopMovementTrigger()
     {
         state.SetPlayerVelocity(0f);
     }

    public virtual void AnimationActionTrigger() { }

    #endregion

    public void InitializeWeapon(PlayerAttackState state, Core core)
    {
        this.state = state;
        this.core = core;
    }
    
}
