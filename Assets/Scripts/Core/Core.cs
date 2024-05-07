using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement { get; private set; }
    public CollisionSenses CollisionSenses { get; private set; }
    public Combat Combat { get; private set; }
    public Stats stats {  get; private set; }     


    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
        Combat = GetComponentInChildren<Combat>();
        stats = GetComponentInChildren<Stats>();    


    }
    public void LogicUpdate()
    {
        Movement.LogicUpdate();

        Combat.LogicUpdate();
    }
    public void FixedUpdate()
    {
        Combat.LogicUpdate();
        Movement.LogicUpdate();
    }
}
       


        

