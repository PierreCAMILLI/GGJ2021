using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHUD : SingletonBehaviour<GameOverHUD>
{
    public void Show(bool toggle)
    {
        this.gameObject.SetActive(toggle);
    }
}
