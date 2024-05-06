using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AggressiveWeapon : Weapon
{
    
    protected SO_AggresiveWeaponData aggresiveWeaponData;

    private List<IDamagable> detectedIDamagables = new List<IDamagable>();
    private List<IKnockbackable> detectedIKnobackables = new List<IKnockbackable>();
    protected override void Awake()
    {
        base.Awake();
        

        if (weaponData.GetType() == typeof(SO_AggresiveWeaponData))
        {
            aggresiveWeaponData = (SO_AggresiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("Wrong data for weapon");
        }
    }
    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();
        CheckMeleAttack();
    }
    private void CheckMeleAttack()
    {

        WeaponAttactDetails details = aggresiveWeaponData.AttackDetails[attackCounter];
        foreach (IDamagable item in detectedIDamagables.ToList())
        {
            
            item.Damage(details.damageAmmount);
            
        }
        foreach (IKnockbackable item in detectedIKnobackables.ToList())
        {
            
            item.Knockback(details.knockbackAngle, details.knockbackStrength, core.Movement.FacingDirection);
           
        }
    }

    public void AddToDetected(Collider2D collision)
    {


        
        IDamagable damageable = collision.GetComponent<IDamagable>();
        
        if (damageable != null)
        {
            
            detectedIDamagables.Add(damageable);

            
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();
        if (knockbackable != null)
        {
            
            detectedIKnobackables.Add(knockbackable);
        }
    }

   

    public void RemoveFromDetected(Collider2D collision)
    {
        
        IDamagable damagable = collision.GetComponent<IDamagable>();
        if (damagable != null)
        {
           
            detectedIDamagables.Remove(damagable);
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();
        if (knockbackable != null)
        {
            
            detectedIKnobackables.Remove(knockbackable);
        }
    }
}
