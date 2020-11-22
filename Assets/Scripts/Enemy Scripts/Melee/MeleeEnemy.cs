using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header("AI")]
    public bool withinRange = false;

    [Space]
    [Header("Jump Variables")]
    public float jumpHeight;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool grounded;
    public float checkRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    public void MeleeBehavior(GameObject player, float speed, float attackRange, Rigidbody2D enemyRb)
    {
        withinRange = false;
        if (!withinRange)
            StartCoroutine(ChaseThePlayer(player, speed, enemyRb));
        else
            Attack();
    }

    IEnumerator ChaseThePlayer(GameObject player, float speed, Rigidbody2D enemyRb)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (player.transform.position.y > transform.position.y + 1 && grounded)
        {
            Jump(enemyRb);
        }
        yield return new WaitForSeconds(.5f);
    }

    //private void ChaseThePlayer(GameObject player, float speed, Rigidbody2D enemyRb)
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    //    if(player.transform.position.y > transform.position.y + 1 && grounded)
    //    {
    //        Jump(enemyRb);
    //    }

    //}

    public void Jump(Rigidbody2D enemyRb)
    {
        enemyRb.velocity = Vector2.up * jumpHeight;
    }

    private void Attack()
    {

    }

    

    
}
