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
    private Transform gunSpriteTransform;

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

    //[SerializeField]
    //private Transform heldWeapon;

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

    [SerializeField]
    float cameraSpeed = 1.1f;

    Vector3 mousePos = new Vector3();
    Vector3 cameraOffset = new Vector3(0, 0, -10);
    Vector3 charPos;
    Vector2 input;
    Vector2 cameraBoost = new Vector2(5f, 5f);

    public SpriteRenderer rKey;

    //Audio
    AudioSource source;
    public AudioClip[] land_Gravel;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        inventory = GetComponent<PlayerInventory>();
        audPlayerMovement = GetComponent<AUDIO_PlayerMovement>();
        //This variable is hold the position the Camera will go ahead of the player towards.
        Vector2 cameraBoost = new Vector2(5f, 5f);
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {

        playerCam.transform.position = new Vector3(transform.position.x, transform.position.y, playerCam.transform.position.z);
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
        animator.SetBool("isGrounded", grounded);
        //RotateItemInHands();
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
        if(grounded == false)
        {
            if(grounded == true)
            {
                source.clip = land_Gravel[Random.Range(0, land_Gravel.Length)];
                source.PlayOneShot(source.clip);
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.position = resetPoint.transform.position;
        }
        animator.SetFloat("DeltaY", playerRigidbody.velocity.y);
        animator.SetFloat("DeltaX", Mathf.Abs(input.x));
        playerCam.transform.position = new Vector3(transform.position.x, transform.position.y, playerCam.transform.position.z);
        //CameraControl();
        //Testing
    }


    //Function to make it so player cannot move. May be needed for several purposes.
    public void SetSpeedToZero()
    {
        speed = 0;
    }

    public void ReturnSpeedToDefault()
    {
        speed = 10;
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
        gunSpriteTransform.Rotate(180, 0, 0);
    }

    private void CameraControl()
    {
        Vector3 cameraGoal;

        if (input.x > 0 && isFacingRight)
        {
            // I just want to get your love and affection <3
            // Calculating the distance that the camera will be away from the player.
            // Based on if the player is moving (Abs(input.x)), the right facing direction of the player (transofrm.right.x), and the distance we want to maintain(cameraboost.x).
            float distanceToMaintain = Mathf.Abs(input.x) * transform.right.x * cameraBoost.x;

            // Give me cuddles uWu
            // Adding the distance we want to maintain to the players position
            // This will calculate the distance the camera should be, relative to the players position
            float xCameraGoal = distanceToMaintain + transform.position.x;

            // Creating a vector pointing to where the camera should be.
            // Taking into account the players y position, and the camera Depth.
            cameraGoal = new Vector3(xCameraGoal, transform.position.y, playerCam.transform.position.z);
        }
        else if (input.x < 0 && !isFacingRight)
        {
            // I just want to get your love and affection <3
            // Calculating the distance that the camera will be away from the player.
            // Based on if the player is moving (Abs(input.x)), the right facing direction of the player (transofrm.right.x), and the distance we want to maintain(cameraboost.x).
            float distanceToMaintain = Mathf.Abs(input.x) * transform.right.x * cameraBoost.x;

            // Give me cuddles uWu
            // Adding the distance we want to maintain to the players position
            // This will calculate the distance the camera should be, relative to the players position
            float xCameraGoal = distanceToMaintain + transform.position.x;

            // Creating a vector pointing to where the camera should be.
            // Taking into account the players y position, and the camera Depth.
            cameraGoal = new Vector3(xCameraGoal, transform.position.y, playerCam.transform.position.z);
        }
        else
            cameraGoal = new Vector3(transform.position.x, transform.position.y, playerCam.transform.position.z);

        StartCoroutine(stayAhead(cameraGoal));
    }

    IEnumerator stayAhead(Vector3 cameraGoal)
    {
        playerCam.transform.position = Vector3.Lerp(playerCam.transform.position, cameraGoal, cameraSpeed);
        yield return new WaitForSeconds(.5f);
    }
}