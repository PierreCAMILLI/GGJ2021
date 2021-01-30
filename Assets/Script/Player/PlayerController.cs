using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerController : SingletonBehaviour<PlayerController> {

    public float speed;
    public GameObject spell;
    public GameObject shockwaveAnimation;
    public GameObject muzzleRight;
    public GameObject muzzleLeft;
    public GameObject[] arraySpellUI;
    public Sprite[] spriteSpellUI;
    public Sprite[] spriteSpell;
    public Sprite[] characterSprite;
    public Slider manaBar;
    public float cooldown;
    public bool isFacingRight = true;
    public float jumpForce;
    public int selectedSpell;
    public float valueJump;
    public float manaCostSpell = 0.3f;
    public float manaCostShockwave = 1f;

    private Rigidbody2D rb;
    private float lastTimeUse;
    private float velocity;
    private bool canJump = true;
    private bool inputIsActive = true;

    private HashSet<ActionTrigger> m_actionTriggers;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        selectedSpell = 0;
        m_actionTriggers = new HashSet<ActionTrigger>();
    }

    //Movement controller
    public void Move(InputAction.CallbackContext context) {
        if (context.ReadValue<Vector2>().x != 0 && inputIsActive) {
            velocity = context.ReadValue<Vector2>().x * speed;
            GetComponent<SpriteRenderer>().sprite = characterSprite[1];
            if (context.ReadValue<Vector2>().x > 0) {
                isFacingRight = GetComponent<SpriteRenderer>().flipX = true;
            }
            else {
                isFacingRight = GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
            velocity = 0;
    }

    //Cast a spell
    public void Fire(InputAction.CallbackContext context) {
        GameObject spellCast;

        if (Time.time > lastTimeUse && inputIsActive) {
            if (PlayerInfos.Instance.CanCast(1)) {
                if (muzzleRight.active)
                    spellCast = (GameObject)Instantiate(spell, muzzleRight.transform.position, muzzleRight.transform.rotation);
                else
                    spellCast = (GameObject)Instantiate(spell, muzzleLeft.transform.position, muzzleLeft.transform.rotation);

                spellCast.GetComponent<SpriteRenderer>().sprite = spriteSpell[(int)PlayerInfos.Instance.SelectedSpell];

                manaBar.value -= 0;

                lastTimeUse = Time.time + cooldown;
            }
        }
    }

    public void Pause(InputAction.CallbackContext context) {
        GlobalEvents.Instance.EventPauseGame.Invoke();
        //Ne fonctionne pas (Cr�e un StackOverflow) donc j'ai mis un boolean un l'arrache pour �viter de perdre trop de temps

        /*if (GetComponent<PlayerInput>().inputIsActive)
            GetComponent<PlayerInput>().DeactivateInput();
        else
            GetComponent<PlayerInput>().ActivateInput();*/
    }

    public void setInputIsActive(bool value) {
        inputIsActive = value;
    }

    public void Shockwave(InputAction.CallbackContext context) {
        if (PlayerInfos.Instance.CanCast(1) && inputIsActive) {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 5f);

            foreach (var hitCollider in hitColliders) {
                if (hitCollider.gameObject.tag.Equals("HiddenObject")) {
                    hitCollider.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (hitCollider.gameObject.tag.Equals("HiddenObjectCollider")) {
                    hitCollider.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    hitCollider.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                }
            }

            if (hitColliders.Length == 0) {
                LoseLife();
            }

            manaBar.value -= 0;
            Instantiate(shockwaveAnimation, transform.position, transform.rotation);
        }
    }

    public void Interact(InputAction.CallbackContext context) {
        if (inputIsActive) {
            Debug.Log("Interact");
            GetComponent<SpriteRenderer>().sprite = characterSprite[2];

            foreach (ActionTrigger trigger in m_actionTriggers) {
                trigger.OnActionInTriggerEvent(this);
                Debug.Log("Interact");
                GetComponent<SpriteRenderer>().sprite = characterSprite[2];
            }
        }
    }

    public void SwitchSpellRight(InputAction.CallbackContext context) {
        if (context.ReadValue<float>() == 1 && inputIsActive) {
            PlayerInfos.Instance.SelectNextSpell();

            arraySpellUI[0].GetComponent<Image>().sprite = spriteSpellUI[(int)PlayerInfos.Instance.PreviousSpell];
            arraySpellUI[1].GetComponent<Image>().sprite = spriteSpellUI[(int)PlayerInfos.Instance.NextSpell];
        }
    }

    public void SwitchSpellLeft(InputAction.CallbackContext context) {
        if (context.ReadValue<float>() == 1 && inputIsActive) {
            PlayerInfos.Instance.SelectPreviousSpell();

            arraySpellUI[0].GetComponent<Image>().sprite = spriteSpellUI[PlayerInfos.Instance.PreviousSpell];
            arraySpellUI[1].GetComponent<Image>().sprite = spriteSpellUI[PlayerInfos.Instance.NextSpell];
        }
    }

    //Jump
    public void Jump(InputAction.CallbackContext context) {
        if (canJump && inputIsActive) {
            if (context.ReadValue<float>() == 1) {
                canJump = false;
                rb.velocity = new Vector2(rb.position.x, jumpForce);
            }
        }
        valueJump = context.ReadValue<float>();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(velocity, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag != "HiddenObject" && other.tag != "HiddenObjectCollider")
            canJump = true;
        else if (other.GetComponent<SpriteRenderer>().enabled)
            canJump = true;

        ActionTrigger trigger = other.gameObject.GetComponent<ActionTrigger>();
        if (trigger) {
            m_actionTriggers.Add(trigger);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        ActionTrigger trigger = collision.gameObject.GetComponent<ActionTrigger>();
        if (trigger) {
            m_actionTriggers.Remove(trigger);
        }
    }

    public void LoseLife() {
        PlayerInfos.Instance.Life--;
        if (PlayerInfos.Instance.Life == 0) {
            //Game Over
        }
    }

    public void DestroyItem(GameObject gameObject) {
        Destroy(gameObject);
    }

    public void DisplayObject(GameObject gameObject) {
        gameObject.SetActive(true);
    }
}
