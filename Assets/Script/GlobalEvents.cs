using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : Singleton<GlobalEvents>
{
    public UnityEvent EventStartTuto { get; }
    public UnityEvent EventStartGame { get; }
    public UnityEvent EventBackToMenu { get; }

    public UnityEvent EventPauseGame { get; }
    public UnityEvent EventResumeGame { get; }

    public GlobalEvents()
    {
        this.EventStartTuto = new UnityEvent();
        this.EventStartGame = new UnityEvent();
        this.EventBackToMenu = new UnityEvent();

        this.EventPauseGame = new UnityEvent();
        this.EventResumeGame = new UnityEvent();
    }
}
