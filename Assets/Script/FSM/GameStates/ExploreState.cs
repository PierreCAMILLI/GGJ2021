using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreState : FSMNode<EMainGameState>
{
    public ExploreState(FSM<EMainGameState> fsm, EMainGameState state) : base(fsm, state) { }

    protected override void OnEnter()
    {
        Debug.Log(ToString() + ": OnEnter");
    }

    protected override void OnExit()
    {
        Debug.Log(ToString() + ": OnExit");
    }
}
