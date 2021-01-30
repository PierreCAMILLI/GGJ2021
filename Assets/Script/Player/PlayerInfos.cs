using UnityEngine;

public class PlayerInfos : SingletonBehaviour<PlayerInfos> {
    [SerializeField]
    private int m_lifeMax = 3;
    public int LifeMax { get { return m_lifeMax; } }

    [SerializeField]
    private float m_timeToFillMagic = 1.0f;

    [SerializeField]
    private Spell[] Spells = new Spell[] { Spell.Fire, Spell.Ice, Spell.Wind };

    private int m_life = 3;
    public int Life {
        get { return m_life; }
        set { m_life = Mathf.Clamp(value, 0, m_lifeMax); }
    }

    private float m_magic = 1.0f;
    public float Magic {
        get { return m_magic; }
        set { m_magic = Mathf.Clamp01(value); }
    }

    private int m_keys = 0;
    public int Keys {
        get { return m_keys; }
        set { m_keys = value; }
    }

    private int m_selectedSpellIndex = 0;

    private bool m_won;
    public bool Won
    {
        get { return m_won; }
        set { m_won = value; }
    }

    public Spell SelectedSpell { get { return this.Spells[m_selectedSpellIndex]; } }
    public int NextSpell { 
        get {
            if (m_selectedSpellIndex == Spells.Length - 1)
                return 0;
            else
                return m_selectedSpellIndex + 1;
        } 
    }
    public int PreviousSpell {
        get {
            if (m_selectedSpellIndex == 0)
                return Spells.Length - 1;
            else
                return m_selectedSpellIndex - 1;
        }
    }

    public void SelectNextSpell() {
        if (m_selectedSpellIndex == Spells.Length - 1)
            m_selectedSpellIndex = 0;
        else
            m_selectedSpellIndex++;

    }

    public void SelectPreviousSpell() {
        if (m_selectedSpellIndex == 0)
            m_selectedSpellIndex = Spells.Length - 1;
        else
            m_selectedSpellIndex--;
    }

    protected override void Awake() {
        base.Awake();
        this.InitGame();
    }

    public void InitGame()
    {
        this.m_life = this.LifeMax;
        this.m_magic = 1.0f;
        this.m_keys = 0;
        this.m_selectedSpellIndex = 0;
        this.m_won = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateMagic();
    }

    private void UpdateMagic()
    {
        if (this.m_timeToFillMagic == 0f)
        {
            this.m_magic = 1f;
        }
        else {
            this.Magic += Time.deltaTime / m_timeToFillMagic;
        }
    }
}
