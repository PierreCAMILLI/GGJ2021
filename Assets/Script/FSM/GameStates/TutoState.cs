using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoState : FSMNode<EGameState>
{
    public TutoState(FSM<EGameState> fsm, EGameState state) : base(fsm, state) { }

    protected override void OnEnter()
    {
        Debug.Log(ToString() + ": OnEnter");
    }

    public override void Update()
    {

    }

    protected override void OnExit()
    {
        Debug.Log(ToString() + ": OnExit");
    }
}
