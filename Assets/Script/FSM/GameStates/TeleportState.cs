using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportState : FSMNode<EMainGameState>
{
    public TeleportState(FSM<EMainGameState> fsm, EMainGameState state) : base(fsm, state) {}

    protected override void Update()
    {
        ChangeState(EMainGameState.Explore);
    }

    protected override void OnEnter()
    {
        Debug.Log(ToString() + ": OnEnter");
    }

    protected override void OnExit()
    {
        Debug.Log(ToString() + ": OnExit");
    }
}
