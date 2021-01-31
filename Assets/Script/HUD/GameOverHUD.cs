using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameOverHUD : SingletonBehaviour<GameOverHUD> {
    public void Show(bool toggle) {
        this.gameObject.SetActive(toggle);
    }

    public void Quit() {
        Application.Quit();
    }

    public void Restart() {
        GlobalEvents.Instance.EventStartGame.Invoke();
    }
}
