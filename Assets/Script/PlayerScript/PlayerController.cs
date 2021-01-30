using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : SingletonBehaviour<PlayerController> {

    public float speed;
    public GameObject spell;
    public GameObject muzzleRight;
    public GameObject muzzleLeft;
    public float cooldown;
    public bool isFacingRight = true;
    public float jumpForce;
    public float valueJump;

    private Rigidbody2D rb;
    private float lastTimeUse;
    private float velocity;
    private bool canJump = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
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

        if (Time.time > lastTimeUse) {
            if (muzzleRight.active)
                Instantiate(spell, muzzleRight.transform.position, muzzleRight.transform.rotation);
            else
                Instantiate(spell, muzzleLeft.transform.position, muzzleLeft.transform.rotation);

            lastTimeUse = Time.time + cooldown;
        }
    }

    public void SwitchSpellRight(InputAction.CallbackContext context) {
        if (context.ReadValue<float>() == 1) {
            PlayerInfos.Instance.SelectNextSpell();
        } 
    }

    public void SwitchSpellLeft(InputAction.CallbackContext context) {
        if (context.ReadValue<float>() == 1) {
            PlayerInfos.Instance.SelectPreviousSpell();
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
