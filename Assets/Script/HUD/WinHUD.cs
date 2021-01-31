using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class WinHUD : SingletonBehaviour<WinHUD>
{
    public void Show(bool toggle)
    {
        this.gameObject.SetActive(toggle);
    }
}
