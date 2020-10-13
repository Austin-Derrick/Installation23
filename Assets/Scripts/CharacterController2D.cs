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
    [SerializeField]
    Camera playerCam;


    Rigidbody2D rb;

    Vector2 input;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;
    Vector3 cameraOffset = new Vector3(0, 0, -10);
    private bool grounded;

    private bool isFacingRight = true;

    Vector3 mousePos = new Vector3();
    Vector3 charPos;

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

        //Updates mouse and character positions
        mouseAndCharacterPosition();

        playerCam.transform.position = gameObject.transform.position + cameraOffset;
        //Character flipping based on mouse position
        if(mousePos.x >= charPos.x && !isFacingRight)
        {
            FlipSprite();
            isFacingRight = true;
        }
        if(mousePos.x <= charPos.x && isFacingRight)
        {
            FlipSprite();
            isFacingRight = false;
        }


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


    //Uses Vector 3 to acquire character position and mouse position 
    //relative to the world coordinates using the player camera.
    private void mouseAndCharacterPosition()
    {
        charPos = gameObject.transform.localPosition;
        mousePos = playerCam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        //Vector2 scaler = transform.localScale;
        //scaler.x *= -1;
        transform.Rotate(0, 180, 0);
    }
}
