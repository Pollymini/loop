using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    protected override void Awake()
    {
        base.Awake();
        currentHealth = maxHealth;
    }

    public void DecreaseHealth(float ammount)
    {
        currentHealth -= ammount;

        if(currentHealth <= 0)
        {
          currentHealth = 0;

            Debug.Log("health is " + currentHealth);
        }
    }

    public void IncreasHealth(float ammount)
    {
        currentHealth = Mathf.Clamp(currentHealth + ammount, 0, maxHealth);
    }
}
