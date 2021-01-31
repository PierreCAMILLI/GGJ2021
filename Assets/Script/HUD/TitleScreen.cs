

using Audio;
using UnityEngine;

public class TitleScreen : SingletonBehaviour<TitleScreen>
{
    [SerializeField] private AudioManager AudioManager;

    public void Start()
    {
        AudioManager.PlayMenuMusic();
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
