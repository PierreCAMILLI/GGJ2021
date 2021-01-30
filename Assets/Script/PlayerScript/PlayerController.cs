using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : SingletonBehaviour<PlayerController> {

    public float speed;
    public GameObject spell;
    public GameObject muzzleRight;
    public GameObject muzzleLeft;
    public float cooldown;
    public static PlayerController instance;
    public bool isFacingRight = true;
    public float jumpForce;
    public int selectedSpell;
    public float valueJump;
    public GameObject[] arraySpell;
    public Sprite[] spriteSpell;

    private string[] spells = { "Fire", "Ice", "Wind" };
    private Rigidbody2D rb;
    private float lastTimeUse;
    private float velocity;
    private bool canJump = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();

        selectedSpell = 0;
    }

    //Movement controller
    public void Move(InputAction.CallbackContext context) {
        if (context.ReadValue<Vector2>().x != 0) {
            velocity = context.ReadValue<Vector2>().x * speed;

            if (context.ReadValue<Vector2>().x > 0)
                isFacingRight = true;
            else
                isFacingRight = false;

        }
        else
            velocity = 0;
    }

    //Cast a spell
    public void Fire(InputAction.CallbackContext context) {

        GameObject spellCast;


        if (Time.time > lastTimeUse) {
            if (muzzleRight.active) {
                spellCast = (GameObject)Instantiate(spell, muzzleRight.transform.position, muzzleRight.transform.rotation);
                spellCast.tag = PlayerInfos.Instance.SelectedSpell.ToString();
                spellCast.GetComponent<SpriteRenderer>().sprite = spriteSpell[(int)PlayerInfos.Instance.SelectedSpell];
            }
            else
                spellCast = (GameObject)Instantiate(spell, muzzleLeft.transform.position, muzzleLeft.transform.rotation);
            spellCast.tag = PlayerInfos.Instance.SelectedSpell.ToString();
            spellCast.GetComponent<SpriteRenderer>().sprite = spriteSpell[(int)PlayerInfos.Instance.SelectedSpell];

            lastTimeUse = Time.time + cooldown;
        }
    }

    public void SwitchSpellRight(InputAction.CallbackContext context) {
        if (context.ReadValue<float>() == 1) {
            PlayerInfos.Instance.SelectNextSpell();

            arraySpell[0].GetComponent<Image>().sprite = spriteSpell[(int)PlayerInfos.Instance.PreviousSpell];
            arraySpell[1].GetComponent<Image>().sprite = spriteSpell[(int)PlayerInfos.Instance.NextSpell];
        }
    }

    public void SwitchSpellLeft(InputAction.CallbackContext context) {
        if (context.ReadValue<float>() == 1) {
            PlayerInfos.Instance.SelectPreviousSpell();

            arraySpell[0].GetComponent<Image>().sprite = spriteSpell[PlayerInfos.Instance.PreviousSpell];
            arraySpell[1].GetComponent<Image>().sprite = spriteSpell[PlayerInfos.Instance.NextSpell];
        }

    }

    //Jump
    public void Jump(InputAction.CallbackContext context) {
        if (canJump) {
            if (context.ReadValue<float>() > 0) {
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
        canJump = true;
    }
}