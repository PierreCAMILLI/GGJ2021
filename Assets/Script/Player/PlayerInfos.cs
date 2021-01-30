using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerInfos : SingletonBehaviour<PlayerInfos>
{
    [SerializeField]
    private int m_lifeMax = 3;
    public int LifeMax { get { return m_lifeMax; } }

    [SerializeField]
    private float m_timeToFillMagic = 1.0f;

    //[SerializeField]
    //private EMagicSpell[] Spells;

    private int m_life = 3;
    public int Life
    {
        get { return m_life; }
        set { m_life = Mathf.Clamp(value, 0, m_lifeMax); }
    }

    private float m_magic = 1.0f;
    public float Magic
    {
        get { return m_magic; }
        set { m_magic = Mathf.Clamp01(value); }
    }

    private int m_keys = 0;
    public int Keys
    {
        get { return m_keys; }
        set { m_keys = value; }
    }

    private int m_selectedSpellIndex = 0;
    //public Spell SelectedSpell { get { return this.Spells[m_selectedSpellIndex]; } }
    //public Spell NextSpell { get { return this.Spells[(m_selectedSpellIndex + 1) % Spells.Length]; } }
    //public Spell NextSpell { get { return this.Spells[(m_selectedSpellIndex - 1) % Spells.Length]; } }

    public void SelectNextSpell()
    {
        //m_selectedSpellIndex = (m_selectedSpellIndex + 1) % Spells.Length;
    }

    public void SelectPreviousSpell()
    {
        //m_selectedSpellIndex = (m_selectedSpellIndex - 1) % Spells.Length;
    }

    protected override void Awake()
    {
        base.Awake();

        this.m_life = this.LifeMax;
        this.m_magic = 1.0f;
        this.m_keys = 0;
        this.m_selectedSpellIndex = 0;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMagic();
    }

    private void UpdateMagic()
    {
        if (m_timeToFillMagic == 0f)
        {
            this.m_magic = 1f;
        }
        else
        {
            this.Magic += Time.deltaTime / m_timeToFillMagic;
        }
    }
}
