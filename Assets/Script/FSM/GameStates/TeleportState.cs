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
        if (BlackScreen.Instance)
        {
            BlackScreen.Instance.SetAlpha(0f);
            BlackScreen.Instance.CrossFadeAlpha(1f, 1f, true);
        }
        m_state = FadeState.FadeIn;
    }

    protected override void Update()
    {
        if (BlackScreen.Instance)
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
        else
        {
            GlobalEvents.Instance.OnBlackScreenFadedEvent.Invoke();
            ChangeState(EMainGameState.Explore);
        }
    }

    protected override void OnExit()
    {
        Debug.Log(ToString() + ": OnExit");
        GlobalEvents.Instance.OnBlackScreenFadedEvent.RemoveAllListeners();
    }
}
