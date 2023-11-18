using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTest : MonoBehaviour, IDamagable
{
    public void Damage(float amount)
    {
        Debug.Log(amount + "Damage Taken");
    }

    
}
