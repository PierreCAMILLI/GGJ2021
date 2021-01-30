using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : FSMNode<EMainGameState>
{
    public GameOverState(FSM<EMainGameState> fsm, EMainGameState state) : base(fsm, state) { }
}
