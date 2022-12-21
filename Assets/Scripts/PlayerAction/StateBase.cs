using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase<T> where T : StateMachineBase<T>
{
    protected T player;
    private bool test;
    public StateBase(T _machine) { player = _machine; }

    public virtual void OnEnterState() { }
    public virtual void OnUpdate() { }
    public virtual void OnExitState() { }

    public virtual void PhysicsUpdate() { }
}
