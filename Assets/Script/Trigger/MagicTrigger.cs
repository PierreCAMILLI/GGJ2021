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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpellController spell = collision.gameObject.GetComponent<SpellController>();
        if (spell)
        {
            if (spell.getType() == m_goodSpellToUse)
            {
                m_onGoodSpellTouchedEvent.Invoke();
            }
            else
            {
                m_onBadSpellTouchedEvent.Invoke();
            }
        }
        
    }
}
