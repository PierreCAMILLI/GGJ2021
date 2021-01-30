using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothJump : MonoBehaviour {

    public float fallMultiplier = 2.5f;
    public float littlejumpMultiplier = 2f;
    public Rigidbody2D rb;


    // Update is called once per frame
    void Update() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && PlayerController.Instance.valueJump == 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (littlejumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
