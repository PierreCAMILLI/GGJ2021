using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeTime = Time.time + lifeTime;

        if (!PlayerController.Instance.isFacingRight)
            speed *= -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (Time.time > lifeTime) {
            Destroy(gameObject);
        }
    }
}
