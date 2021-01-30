using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : Singleton<GlobalEvents>
{
    public UnityEvent EventStartTuto { get; }
    public UnityEvent EventStartGame { get; }
    public UnityEvent EventBackToMenu { get; }

    public UnityEvent EventTeleport { get; }
    public UnityEvent EventPauseGame { get; }
    public UnityEvent EventResumeGame { get; }
    public UnityEvent EventSafeBackToMenu { get; }

    public UnityEvent OnBlackScreenFadedEvent { get; }

    public GlobalEvents()
    {
        this.EventStartTuto = new UnityEvent();
        this.EventStartGame = new UnityEvent();
        this.EventBackToMenu = new UnityEvent();

        this.EventTeleport = new UnityEvent();
        this.EventPauseGame = new UnityEvent();
        this.EventResumeGame = new UnityEvent();
        this.EventSafeBackToMenu = new UnityEvent();

        this.OnBlackScreenFadedEvent = new UnityEvent();
    }
}
