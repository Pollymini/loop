using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class WeaponAnimationToWeapon : MonoBehaviour
{
 
    private Weapon weapon;
   
    private void Start()
    {
        weapon = GetComponentInParent<Weapon>();
    }




    private void AnimationFinishTriggerForWeapon()
    {
        weapon.AnimationFinishTriggerForAll();
    }


     private void AnimationStartMovemementTrigger()
     {
         weapon.AnimationStartMovementTrigger();
     }
     private void AnimationStopMovemementTrigger()
     {
          weapon.AnimationStopMovementTrigger();
     }
    private void AnimationActionTrigger()
    {
        weapon.AnimationActionTrigger();
    }
}
