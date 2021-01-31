using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinItem : MonoBehaviour
{
    public void Win()
    {
        PlayerInfos.Instance.Won = true;
    }
}
