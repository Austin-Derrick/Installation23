using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Attributes")]
    public float speed;
    private Rigidbody2D enemyRb;
    private GameObject player;

    [Space]
    [Header("Jump Variables")]
    public float jumpHeight;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool grounded;
    public float checkRadius;

    [Space]
    [Header("AI")]
    public bool goodToAttack = true;
    


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int nonPlayer = 1 << 9;
        nonPlayer = ~nonPlayer;
        RaycastHit2D hit;

        //Checks to see if the player is within range of the enemy AI
        hit = Physics2D.Raycast(transform.position, player.transform.position, nonPlayer);
        if (hit && goodToAttack)
        {
            ChaseThePlayer();
        }

        
        
    }

    

    private void ChaseThePlayer()
    {
        // Set enemy direction towards player and move there
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (player.transform.position.y > transform.position.y + 1 && grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        enemyRb.velocity = Vector2.up * jumpHeight;
    }

    public IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(1.5f);
        goodToAttack = true;
    }
}
