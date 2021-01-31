using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHUD : SingletonBehaviour<WinHUD>
{
    public void Show(bool toggle)
    {
        this.gameObject.SetActive(toggle);
    }
}
