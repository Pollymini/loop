using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagable : MonoBehaviour, IDamagable, IKnockbackable
{
    public BasicEnemyScript bES;

    public void Damage(float ammount)
    {
        bES.Damage(ammount);
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        Debug.Log("Knockback");
    }
}
