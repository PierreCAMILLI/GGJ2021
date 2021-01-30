using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<PlayerController> m_onActionInTriggerEvent;

    public void OnActionInTriggerEvent(PlayerController player)
    {
        m_onActionInTriggerEvent.Invoke(player);
    }
}
