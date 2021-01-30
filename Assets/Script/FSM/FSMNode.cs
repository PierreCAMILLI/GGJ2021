using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMNode<E>
{
    public E State { get; }
    public FSM<E> FSM { get; }

    protected float StateTime { get; private set; }

    public FSMNode(FSM<E> fsm, E state)
    {
        this.FSM = fsm;
        this.State = state;
    }

    public virtual void Init() { }
    protected virtual void OnEnter() { }
    protected virtual void Update() { }
    protected virtual void OnExit() { }

    public void Enter()
    {
        this.StateTime = Time.time;
        this.OnEnter();
    }

    public void Execute()
    {
        this.Update();
    }

    public void Exit()
    {
        this.OnExit();
    }

    protected void ChangeState(E newState)
    {
        FSM.CurrentState = newState;
    }

    public override string ToString()
    {
        return "State(" + State.ToString() + ")";
    }
}
