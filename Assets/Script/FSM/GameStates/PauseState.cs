using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : FSMNode<EMainGameState>
{
    private bool m_resumeGame;

    public PauseState(FSM<EMainGameState> fsm, EMainGameState state) : base(fsm, state) { }

    protected override void OnEnter()
    {
        GlobalEvents.Instance.EventResumeGame.AddListener(this.ResumeGame);
        this.m_resumeGame = false;
        Time.timeScale = 0f;
    }

    protected override void Update()
    {
        if (this.m_resumeGame)
        {
            ChangeState(EMainGameState.Explore);
        }
    }

    protected override void OnExit()
    {
        GlobalEvents.Instance.EventResumeGame.RemoveListener(this.ResumeGame);
        Time.timeScale = 1f;
    }

    private void ResumeGame()
    {
        this.m_resumeGame = true;
    }
}
