using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMashine stateMachine;

    protected Entity entity;

    protected Core core;

    protected float startTime;

    protected string animBoolName;

    public State(Entity entity, FiniteStateMashine stateMashine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMashine;
        this.animBoolName = animBoolName;
        core = entity.Core;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
        DoChecks();
    }
    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
}
