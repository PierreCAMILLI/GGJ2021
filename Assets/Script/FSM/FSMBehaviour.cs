using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameState
{
    MainMenu,
    Tuto,
    MainGame
}

public class GameFSM : FSM<EGameState>
{
    public GameFSM() : base() { }

    public override void CreateFSM()
    {
        this.AddState(new MainMenuState(this, EGameState.MainMenu));
        this.AddState(new MainGameState(this, EGameState.MainGame));
        this.AddState(new TutoState(this, EGameState.Tuto));
        this.RootState = EGameState.MainMenu;
    }
}

public class FSMBehaviour : MonoBehaviour
{
    private GameFSM FSM { get; set; }

    void Awake()
    {
        this.FSM = new GameFSM();
        this.FSM.CreateFSM();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.FSM.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        this.FSM.Update();
    }
}
