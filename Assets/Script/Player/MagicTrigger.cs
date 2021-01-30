using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MagicTrigger : MonoBehaviour
{
    [SerializeField]
    private Spell m_goodSpellToUse;

    [SerializeField]
    private UnityEvent m_onGoodSpellTouchedEvent;

    [SerializeField]
    private UnityEvent m_onBadSpellTouchedEvent;

    private void OnCollisionEnter(Collision collision)
    {
        SpellController spell = collision.gameObject.GetComponent<SpellController>();
        if (spell)
        {
            //if (spell.)
        }
    }
}
