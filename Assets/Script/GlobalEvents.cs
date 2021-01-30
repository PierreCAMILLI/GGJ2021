using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : Singleton<GlobalEvents>
{
    public UnityEvent EventBackToMenu { get; }

    public UnityEvent EventPauseGame { get; }
    public UnityEvent EventResumeGame { get; }

    public GlobalEvents()
    {
        this.EventBackToMenu = new UnityEvent();
        this.EventPauseGame = new UnityEvent();
        this.EventResumeGame = new UnityEvent();
    }
}
