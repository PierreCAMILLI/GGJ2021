using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : FSMNode<EMainGameState>
{
    private bool m_backToMenu;

    public GameOverState(FSM<EMainGameState> fsm, EMainGameState state) : base(fsm, state) { }

    protected override void OnEnter()
    {
        GlobalEvents.Instance.EventSafeBackToMenu.AddListener(BackToMenu);
        m_backToMenu = false;
    }

    protected override void OnExit()
    {
        GlobalEvents.Instance.EventSafeBackToMenu.RemoveListener(BackToMenu);
    }

    private void BackToMenu()
    {
        m_backToMenu = true;
    }
}
