using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeDoor : MonoBehaviour
{

    public BoxCollider2D Trigger;

    public void HitPlayer()
    {
        PlayerController.Instance.TakeDamage(1);
        Trigger.enabled = false;
        Trigger.enabled = true;
    }
}
