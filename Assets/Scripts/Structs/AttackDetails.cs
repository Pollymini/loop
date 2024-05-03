using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct AttackDetails
{
    public Vector2 position;
    public float damageAmmount;

    public float stunDamageAmount; 
}



[System.Serializable]
public struct WeaponAttactDetails
{
    public string attackName;
    public float movementSpeed;
    public float damageAmmount;
   

    public float knockbackStrength;
    public Vector2 knockbackAngle;

 
}


