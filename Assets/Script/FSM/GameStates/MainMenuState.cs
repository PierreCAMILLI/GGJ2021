using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : FSMNode<EGameState>
{
    public MainMenuState(FSM<EGameState> fsm, EGameState state) : base(fsm, state) { }

    protected override void OnEnter()
    {
        Debug.Log(ToString() + ": OnEnter");
    }

    public override void Update()
    {
        if (Time.time >= this.StateTime + 3)
        {
            ChangeState(EGameState.MainGame);
        }
    }

    protected override void OnExit()
    {
        Debug.Log(ToString() + ": OnExit");
    }
}
