using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomperScript : MonoBehaviour
{

    public BoxCollider2D TriggerArea;
    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            TriggerArea.enabled = false;
            rb.gravityScale = 1;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + -speed);
        }
    }


}
