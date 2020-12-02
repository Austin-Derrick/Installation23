using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    PlayerInventory inventory;

    [Tooltip("Movement speed of the player")]
    public float speed = 10;
    [SerializeField]
    float cameraSpeed = 1.1f;

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
    public GameObject player;

    private bool isFacingRight = true;

    Vector3 mousePos = new Vector3();
    Vector3 cameraOffset = new Vector3(0, 0, -10);
    Vector3 charPos;
    Vector2 input;
    //This variable is hold the position the Camera will go ahead of the player towards.
    Vector2 cameraBoost = new Vector2(5, 5);
    

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

    private void Start()
    {
        playerCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, playerCam.transform.position.z);

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

        CameraControl();
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

    private void CameraControl()
    {
        float xCameraGoal = input.x * (transform.position.x + cameraBoost.x);
        Vector3 cameraGoal = new Vector3(xCameraGoal, transform.position.y, playerCam.transform.position.z);
        //if(input.x > 0 || input.x < 0)
        //    cameraGoal = new Vector3((input.x * cameraBoost.x), transform.position.y, playerCam.transform.position.z);
        //else
        //   cameraGoal = new Vector3(transform.position.x, transform.position.y, playerCam.transform.position.z);

        playerCam.transform.position = Vector3.Lerp(playerCam.transform.position, cameraGoal, cameraSpeed);
        //if (playerCam.transform.position.x >= cameraGoal.x)
        //{
        //    cameraSpeed = speed;
        //}
        //else
        //{
        //    //The 1 can be changed, is how much faster the camera will be than the player
        //    //cameraSpeed = speed + 1;
        //}
    }
}