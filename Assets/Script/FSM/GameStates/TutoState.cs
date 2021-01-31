using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoState : FSMNode<EGameState>
{
    private bool m_startGame = false;

    public TutoState(FSM<EGameState> fsm, EGameState state) : base(fsm, state) { }

    public override void Init()
    {
        if (Tuto.Instance)
        {
            Tuto.Instance.gameObject.SetActive(false);
        }
    }

    protected override void OnEnter()
    {
        if (SceneManager.GetActiveScene().name != "TitleScreen")
        {
            SceneManager.LoadScene("TitleScreen", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
        if (Tuto.Instance)
        {
            Tuto.Instance.gameObject.SetActive(true);
        }
        GlobalEvents.Instance.EventStartGame.AddListener(StartGame);
        m_startGame = false;
    }

    protected override void Update()
    {
        if (m_startGame)
        {
            ChangeState(EGameState.MainGame);
        }
    }

    protected override void OnExit()
    {
        if (Tuto.Instance)
        {
            Tuto.Instance.gameObject.SetActive(false);
        }
        GlobalEvents.Instance.EventStartGame.RemoveListener(StartGame);
        Audio.AudioManager.Instance.StopMenuMusic();
        Debug.Log(ToString() + ": OnExit");
    }

    private void StartGame()
    {
        m_startGame = true;
    }
}
