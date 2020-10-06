using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Tooltip("Movement speed of the player")]
    public float speed = 10;

    public float jumpHeight = 50;

    float maxSpeed = 20;

    new BoxCollider2D  collider;

    Rigidbody2D rb;

    Vector2 input;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    private bool grounded;

    private bool isFacingRight = true;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.velocity = new Vector2(input.x * speed, rb.velocity.y);
        }
        
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        if (!isFacingRight && input.x > 0)
        {
            FlipSprite();
        }
        else if (isFacingRight && input.x < 0)
        {
            FlipSprite();
        }

        if (grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpHeight;

        }
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        //Vector2 scaler = transform.localScale;
        //scaler.x *= -1;
        transform.Rotate(0, 180, 0);
    }
}
