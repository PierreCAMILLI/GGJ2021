using UnityEngine;

public class TitleScreen : SingletonBehaviour<TitleScreen>
{

    private void Start() {
        
    }

    public void StartGame()
    {
        GlobalEvents.Instance.EventStartTuto.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
