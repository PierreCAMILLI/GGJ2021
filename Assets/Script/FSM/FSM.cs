using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNotIncludedException<E> : System.Exception
{
    public StateNotIncludedException() { }

    public StateNotIncludedException(E state)
        : base("State missing from State Machine: " + state.ToString()) { }
}

public abstract class FSM<E>
{
    public E CurrentState { get; set; }
    public E RootState { get; protected set; }
    private Dictionary<E, FSMNode<E>> States { get; set; }

    public FSM()
    {
        this.States = new Dictionary<E, FSMNode<E>>();
    }

    public abstract void CreateFSM();

    public void Enter()
    {
        this.CurrentState = this.RootState;
        FSMNode<E> node;
        if (this.States.TryGetValue(this.CurrentState, out node))
        {
            node.Enter();
        }
        else
        {
            throw new StateNotIncludedException<E>(this.CurrentState);
        }
    }

    public void Update()
    {
        bool isDifferentState = true;
        E state = this.CurrentState;
        while (isDifferentState)
        {
            FSMNode<E> node;
            if (this.States.TryGetValue(state, out node))
            {
                node.Update();
                isDifferentState = !state.Equals(this.CurrentState);
                if (isDifferentState)
                {
                    node.Exit();

                    state = this.CurrentState;
                    if (this.States.TryGetValue(state, out node))
                    {
                        node.Enter();
                    }
                    else
                    {
                        throw new StateNotIncludedException<E>(this.CurrentState);
                    }
                }
            }
            else
            {
                throw new StateNotIncludedException<E>(this.CurrentState);
            }
        }
    }

    public void Exit()
    {
        FSMNode<E> node;
        if (this.States.TryGetValue(this.CurrentState, out node))
        {
            node.Exit();
        }
        else
        {
            throw new StateNotIncludedException<E>(this.CurrentState);
        }
    }

    protected void AddState(FSMNode<E> newState)
    {
        newState.Init();
        this.States.Add(newState.State, newState);
    }
}
