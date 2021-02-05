using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * 10, rb2d.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Platform")
            rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
        else if (other.tag == "Hazard") {
            rb2d.velocity = new Vector2(0,0);
            GameManager.instance.GameOver = false;
        }
    }
}
