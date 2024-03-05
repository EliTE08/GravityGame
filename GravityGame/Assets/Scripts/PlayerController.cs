using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horiz*speed*Time.deltaTime, rb.velocity.y);
        Debug.Log(horiz);

        if(Input.GetButtonDown("Jump")){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce*Time.deltaTime);
        }
    }
}
