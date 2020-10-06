using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Header("Movement Attributes")]
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpHeight;

    [SerializeField]
    private float maxSpeed;

    [Space]
    [Header("Camera Attributes")]
    [SerializeField]
    private Camera playerCam;

    [SerializeField]
    private Vector3 cameraOffset;

    private float jumpForce;

    private Vector3 charPos;
    private Vector3 mousePos;
    new BoxCollider2D  collider;

    Rigidbody2D rb;

    Vector2 input;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool isJumping;
    private bool jumpKeyHeld;

    Vector2 counterJumpForce = Vector2.down * 100;

    private bool isFacingRight = true;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        jumpForce = CalculateJumpForce(Physics2D.gravity.magnitude, jumpHeight);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.velocity = new Vector2(input.x * speed, rb.velocity.y);
        }
        
        if(isJumping)
        {
            if(!jumpKeyHeld && Vector2.Dot(rb.velocity, Vector2.up) > 0)
            {
                rb.AddForce(counterJumpForce * rb.mass);
            }
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
            FlipSprite(-1);
            isFacingRight = true;
        }
        if(mousePos.x <= charPos.x && isFacingRight)
        {
            FlipSprite(-1);
            isFacingRight = false;
        }

        input.x = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            jumpKeyHeld = true;
            if(isGrounded)
            {
                isJumping = true;
                rb.AddForce(Vector2.up * jumpForce * rb.mass, ForceMode2D.Impulse);
            }
        }
        else if(Input.GetButtonUp("Jump"))
        {
            jumpKeyHeld = false;
        }
        /*
        if (!isFacingRight && input.x > 0)
        {
            FlipSprite();
        }
        else if (isFacingRight && input.x < 0)
        {
            FlipSprite();
        }
        
        
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpHeight;

        }    
        */
    }

    //Uses Vector 3 to acquire character position and mouse position 
    //relative to the world coordinates using the player camera.
    private void mouseAndCharacterPosition()
    {
        charPos = gameObject.transform.localPosition;
        mousePos = playerCam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FlipSprite(int direction)
    {
        //isFacingRight = !isFacingRight;
        Vector2 scaler = transform.localScale;
        //scaler.x *= -1;
        scaler.x *= direction;
        transform.localScale = scaler;
    }

    public float CalculateJumpForce(float gravityStrength, float jumpHeight)
    {
        return Mathf.Sqrt(2 * gravityStrength * jumpHeight);
    }
}
