using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EMainGameState
{
    //InitGame,             // State in order to initiate game
    Explore,
    Pause,
    Win,
    GameOver,

    TeleportTransition    // State to handle transition time during teleportations
}

public class MainGameState : FSMNode<EGameState>
{
    private bool m_requestBackToMenu = false;

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
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        GlobalEvents.Instance.EventBackToMenu.AddListener(RequestBackToMenu);
        m_requestBackToMenu = false;

        this.MainGameFSM.Enter();
    }

    protected override void Update()
    {
        if (m_requestBackToMenu)
        {
            ChangeState(EGameState.MainMenu);
        }
        this.MainGameFSM.Update();
    }

    protected override void OnExit()
    {
        this.MainGameFSM.Exit();

        Debug.Log(ToString() + ": OnExit");
        GlobalEvents.Instance.EventBackToMenu.RemoveListener(RequestBackToMenu);
    }

    private void RequestBackToMenu()
    {
        m_requestBackToMenu = true;
    }
}

public class MainGameFSM : FSM<EMainGameState>
{
    public override void CreateFSM()
    {
        this.AddState(new ExploreState(this, EMainGameState.Explore));
        this.AddState(new PauseState(this, EMainGameState.Pause));
        this.AddState(new GameOverState(this, EMainGameState.GameOver));
        this.AddState(new WinState(this, EMainGameState.Win));
        this.AddState(new TeleportState(this, EMainGameState.TeleportTransition));
        this.RootState = EMainGameState.Explore;
    }
}
