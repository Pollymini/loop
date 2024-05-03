using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FiniteStateMashine 
{
    public State currentState { get; private set; }

    public void Initialize(State startingSTate)
    {
        currentState = startingSTate;
        currentState.Enter();


    }
    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

}
