using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHUD : SingletonBehaviour<GameOverHUD>
{
    public void Show(bool toggle)
    {
        this.gameObject.SetActive(toggle);
    }
}
