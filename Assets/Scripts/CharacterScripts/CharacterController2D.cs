using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    PlayerInventory inventory;

    [Tooltip("Movement speed of the player")]
    public float speed = 10;

    [SerializeField]
    Camera playerCam;

    [SerializeField]
    GameObject resetPoint;

    public float jumpHeight = 50;

    float maxSpeed = 20;

    new BoxCollider2D collider;

    Rigidbody2D rb;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float checkRadius;
    public bool grounded;
    private bool canDoubleJump;

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


        //playerCam.transform.position = gameObject.transform.position + cameraOffset;

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

        //Jumping from ground
        if (grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            canDoubleJump = true;
            rb.velocity = rb.velocity + Vector2.up * jumpHeight;
        }

        //Jumping Mid-Air
        if (grounded == false && canDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            canDoubleJump = false;
            //"v" saves current X and Y velocity, foribly changes the Y to be a fraction of normal jump height, then sets the RB velocity. 
            //Prevents combining the two jump velocities into a super jump by button mashing.
            Vector2 v = rb.velocity;
            v.y = jumpHeight * .8f;
            rb.velocity = v;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.position = resetPoint.transform.position;
        }
        animator.SetFloat("DeltaX", Mathf.Abs(input.x));

        //Testing
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