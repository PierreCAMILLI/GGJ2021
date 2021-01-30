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
        get { return m_blackScreen.canvasRenderer.GetAlpha(); }
    }

    public void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
    {
        m_blackScreen.CrossFadeAlpha(alpha, duration, ignoreTimeScale);
    }

    public void SetAlpha(float alpha)
    {
        m_blackScreen.canvasRenderer.SetAlpha(alpha);
    }

    private void Start()
    {
        SetAlpha(0f);
    }
}
