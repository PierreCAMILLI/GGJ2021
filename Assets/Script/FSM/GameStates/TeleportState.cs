using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportState : FSMNode<EMainGameState>
{
    private enum FadeState
    {
        FadeIn,
        FadeOut
    }

    private FadeState m_state;

    public TeleportState(FSM<EMainGameState> fsm, EMainGameState state) : base(fsm, state) {}

    protected override void OnEnter()
    {
        Debug.Log(ToString() + ": OnEnter");
        BlackScreen.Instance.CrossFadeAlpha(1f, 1f, true);
        m_state = FadeState.FadeIn;
    }

    protected override void Update()
    {
        switch (m_state)
        {
            case FadeState.FadeIn:
                if (BlackScreen.Instance.Alpha == 1f)
                {
                    BlackScreen.Instance.CrossFadeAlpha(0f, 1f, true);
                    GlobalEvents.Instance.OnBlackScreenFadedEvent.Invoke();
                    m_state = FadeState.FadeOut;
                }
                break;
            case FadeState.FadeOut:
                if (BlackScreen.Instance.Alpha == 0f)
                {
                    ChangeState(EMainGameState.Explore);
                }
                break;
        }
    }

    protected override void OnExit()
    {
        Debug.Log(ToString() + ": OnExit");
        GlobalEvents.Instance.OnBlackScreenFadedEvent.RemoveAllListeners();
    }
}
