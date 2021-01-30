using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : SingletonBehaviour<TitleScreen>
{
    public void StartGame()
    {
        GlobalEvents.Instance.EventStartTuto.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
