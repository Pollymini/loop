using QFSW.QC.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newAggressiveWeaponData", menuName = "Data/Weapon Data/AggressiveWeapon")]


public class SO_AggresiveWeaponData : SO_WeaponData
{
    [SerializeField] private WeaponAttactDetails[] attactDetails;

    public WeaponAttactDetails[] AttackDetails { get => attactDetails; private set => attactDetails = value; }
    

    private void OnEnable()
    {
        amountOfAttacks = attactDetails.Length;

        movementSpeed = new float[amountOfAttacks];

        for (int i = 0; i < amountOfAttacks; i++)
        {
            movementSpeed[i] = attactDetails[i].movementSpeed;
        }
        
    }
}
