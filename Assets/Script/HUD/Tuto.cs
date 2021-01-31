using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tuto : SingletonBehaviour<Tuto>
{
    [SerializeField]
    private RectTransform[] m_tutoScreens;

    private int m_screenIndex;

    void Start() {
        foreach(Transform child in transform) {
            if(child.GetComponent<Button>() != null)
                EventSystem.current.SetSelectedGameObject(child.gameObject);
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ResetTuto();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_tutoScreens.Length; ++i)
        {
            m_tutoScreens[i].gameObject.SetActive(m_screenIndex == i);
        }
    }

    public void ResetTuto()
    {
        m_screenIndex = 0;
    }

    public void NextTuto()
    {
        ++m_screenIndex;
        if (m_screenIndex >= m_tutoScreens.Length)
        {
            GlobalEvents.Instance.EventStartGame.Invoke();
        }
    }
}
