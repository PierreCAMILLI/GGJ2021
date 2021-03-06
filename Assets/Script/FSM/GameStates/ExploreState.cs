using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreState : FSMNode<EMainGameState>
{
    private bool m_pauseGame;
    private bool m_teleport;

    public ExploreState(FSM<EMainGameState> fsm, EMainGameState state) : base(fsm, state) { }

    protected override void OnEnter()
    {
        Debug.Log(ToString() + ": OnEnter");
        GlobalEvents.Instance.EventPauseGame.AddListener(this.PauseGame);
        GlobalEvents.Instance.EventTeleport.AddListener(this.Teleport);
        m_pauseGame = false;
        m_teleport = false;
        PlayerController.Instance.setInputIsActive(true);
        GameOverHUD.Instance.Show(false);
        WinHUD.Instance.Show(false);
    }

    protected override void Update()
    {
        if (this.m_teleport)
        {
            ChangeState(EMainGameState.TeleportTransition);
            return;
        }
        if (this.m_pauseGame)
        {
            ChangeState(EMainGameState.Pause);
            return;
        }
        if (PlayerInfos.Instance != null)
        {
            if (PlayerInfos.Instance.Life == 0)
            {
                ChangeState(EMainGameState.GameOver);
                return;
            }
            if (PlayerInfos.Instance.Won)
            {
                ChangeState(EMainGameState.Win);
                return;
            }
        }
    }

    protected override void OnExit()
    {
        Debug.Log(ToString() + ": OnExit");
        GlobalEvents.Instance.EventPauseGame.RemoveListener(this.PauseGame);
        GlobalEvents.Instance.EventTeleport.RemoveListener(this.Teleport);
        PlayerController.Instance.setInputIsActive(false);
    }

    private void PauseGame()
    {
        this.m_pauseGame = true;
    }

    private void Teleport()
    {
        this.m_teleport = true;
    }
}
