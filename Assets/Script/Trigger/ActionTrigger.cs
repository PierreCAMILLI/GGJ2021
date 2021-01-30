using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent m_onActionInTriggerEvent;

    public void OnActionInTriggerEvent()
    {
        m_onActionInTriggerEvent.Invoke();
    }
}
