using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EMainGameState
{
    //InitGame,             // State in order to initiate game
    Explore,
    Pause,
    Win,
    GameOver,

    //TeleportTransition    // State to handle transition time during teleportations
}

public class MainGameState : FSMNode<EGameState>
{
    private MainGameFSM MainGameFSM { get; set; }

    public MainGameState(FSM<EGameState> fsm, EGameState state) : base(fsm, state) { }

    public override void Init()
    {
        this.MainGameFSM = new MainGameFSM();
        this.MainGameFSM.CreateFSM();
    }

    protected override void OnEnter()
    {
        Debug.Log(ToString() + ": OnEnter");
        this.MainGameFSM.Enter();
    }

    public override void Update()
    {
        if (Time.time >= this.StateTime + 3)
        {
            ChangeState(EGameState.MainMenu);
        }
        this.MainGameFSM.Update();
    }

    protected override void OnExit()
    {
        this.MainGameFSM.Exit();
        Debug.Log(ToString() + ": OnExit");
    }
}

public class MainGameFSM : FSM<EMainGameState>
{
    public override void CreateFSM()
    {
        this.AddState(new ExploreState(this, EMainGameState.Explore));
        this.RootState = EMainGameState.Explore;
    }
}
