using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : FSMNode<EGameState>
{
    private bool m_startTuto;

    public MainMenuState(FSM<EGameState> fsm, EGameState state) : base(fsm, state) { }

    public override void Init()
    {
        if (TitleScreen.Instance)
        {
            TitleScreen.Instance.gameObject.SetActive(false);
        }
    }

    protected override void OnEnter()
    {
        if (SceneManager.GetActiveScene().name != "TitleScreen")
        {
            SceneManager.LoadScene("TitleScreen", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
        if (TitleScreen.Instance)
        {
            TitleScreen.Instance.gameObject.SetActive(true);
        }
        GlobalEvents.Instance.EventStartTuto.AddListener(StartTuto);
        m_startTuto = false;
    }

    protected override void Update()
    {
        if (m_startTuto)
        {
            ChangeState(EGameState.Tuto);
        }
    }

    protected override void OnExit()
    {
        if (TitleScreen.Instance)
        {
            TitleScreen.Instance.gameObject.SetActive(false);
        }
        
        GlobalEvents.Instance.EventStartTuto.RemoveListener(StartTuto);
    }

    private void StartTuto()
    {
        m_startTuto = true;
    }
}
