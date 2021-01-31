using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHUD : SingletonBehaviour<PauseHUD> {
    public void Show(bool toggle) {
        this.gameObject.SetActive(toggle);
    }
}
