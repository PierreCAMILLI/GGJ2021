using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitGame : FSMNode<EMainGameState>
{
    AsyncOperation m_asyncOperation;

    public InitGame(FSM<EMainGameState> fsm, EMainGameState state) : base(fsm, state) { }

    protected override void OnEnter()
    {
        m_asyncOperation = SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Single);
    }

    protected override void Update()
    {
        if (m_asyncOperation.isDone)
        {
            ChangeState(EMainGameState.Explore);
        }
    }
}
