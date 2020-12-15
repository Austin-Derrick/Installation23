using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    #region Component Initialization
    public Animator animator;
    private Rigidbody2D playerRigidbody;
    private CapsuleCollider2D capsuleCollider;

    [SerializeField]
    PlayerInventory inventory;

    AUDIO_PlayerMovement audPlayerMovement;
    #endregion

    #region Player Stats
    [Tooltip("Movement speed of the player")]
    [SerializeField]
    private float speed = 10;

    [SerializeField]
    Camera playerCam;

    [SerializeField]
    GameObject resetPoint;

    [SerializeField]
    private float jumpHeight = 50;

    [SerializeField]
    private float maxSpeed = 20;

    //Jumping Bools
    public bool grounded;
    private bool canDoubleJump;
    #endregion

    #region Environment Data
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float checkRadius;
    #endregion

    private bool isFacingRight = true;

    Vector3 mousePos = new Vector3();
    Vector3 cameraOffset = new Vector3(0, 0, -10);
    Vector3 charPos;
    Vector2 input;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        inventory = GetComponent<PlayerInventory>();
        audPlayerMovement = GetComponent<AUDIO_PlayerMovement>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (playerRigidbody.velocity.magnitude <= maxSpeed)
        {
            playerRigidbody.velocity = new Vector2(input.x * speed, playerRigidbody.velocity.y);
        }
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (playerRigidbody.velocity.magnitude > maxSpeed)
        {
            playerRigidbody.velocity = new Vector2(input.x * speed, playerRigidbody.velocity.y);
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
            audPlayerMovement.jumps();
            canDoubleJump = true;
            playerRigidbody.velocity = playerRigidbody.velocity + Vector2.up * jumpHeight;
        }

        //Jumping Mid-Air
        if (grounded == false && canDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            canDoubleJump = false;
            //"v" saves current X and Y velocity, foribly changes the Y to be a fraction of normal jump height, then sets the RB velocity. 
            //Prevents combining the two jump velocities into a super jump by button mashing.
            Vector2 v = playerRigidbody.velocity;
            v.y = jumpHeight * .8f;
            playerRigidbody.velocity = v;
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