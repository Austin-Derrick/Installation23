using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField]
    PlayerInventory inventory;

    [Tooltip("Movement speed of the player")]
    public float speed = 10;

    [SerializeField]
    Camera playerCam;

    public float jumpHeight = 50;

    float maxSpeed = 20;

    new BoxCollider2D  collider;

    Rigidbody2D rb;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float checkRadius;
    private bool grounded;

    private bool isFacingRight = true;

    Vector3 mousePos = new Vector3();
    Vector3 cameraOffset = new Vector3(0, 0, -10);
    Vector3 charPos;
    Vector2 input;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        inventory = GetComponent<PlayerInventory>();
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
        input.x = Input.GetAxis("Horizontal");

        //Updates mouse and character positions
        mouseAndCharacterPosition();


        playerCam.transform.position = gameObject.transform.position + cameraOffset;

        //Character flipping based on mouse position
        if (mousePos.x >= charPos.x && !isFacingRight)
        {
            FlipSprite();
            isFacingRight = true;
        }
        if (mousePos.x <= charPos.x && isFacingRight)
        {
            FlipSprite();
            isFacingRight = false;
        }

        if (grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.velocity = rb.velocity + Vector2.up * jumpHeight;
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
        transform.Rotate(0, 180, 0);
    }
}