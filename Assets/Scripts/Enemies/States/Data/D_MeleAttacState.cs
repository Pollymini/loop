using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleAttackStateData", menuName = "Data/State Data/Mele Attack State")]
public class D_MeleAttacState : ScriptableObject
{
    public float attactRadious = 0.5f;
    public float attackDamage = 10f;

    public Vector2 knockbackAngle = Vector2.one;
    public float knockBackStrength = 10f;

    public LayerMask whatIsPlayer;
}
