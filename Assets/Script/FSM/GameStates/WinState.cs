using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : FSMNode<EMainGameState>
{
    public WinState(FSM<EMainGameState> fsm, EMainGameState state) : base(fsm, state) { }
}
