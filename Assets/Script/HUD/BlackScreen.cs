using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : SingletonBehaviour<BlackScreen>
{
    [SerializeField]
    private Image m_blackScreen;

    public float Alpha
    {
        get { return m_blackScreen.color.a; }
    }

    public void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
    {
        m_blackScreen.CrossFadeAlpha(alpha, duration, ignoreTimeScale);
    }
}
