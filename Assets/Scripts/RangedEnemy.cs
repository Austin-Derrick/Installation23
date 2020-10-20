using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public float offsetValue = 5.0f;
    public Vector2 offsetLoc;
    public float desiredAttackRange = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RangedBehavior(GameObject player, float speed, float attackRange)
    {
        MaintainDistance(player, speed);
    }

    private void MaintainDistance(GameObject player, float speed)
    {
        offsetLoc = player.transform.position;
        if (transform.position.x >= player.transform.position.x)
        {
            //When player is to the left of the enemy
            offsetLoc.x = transform.position.x + offsetValue;
            Debug.Log("Player is to the left of the enemy");
            if ((player.transform.position.x - transform.position.x) >= desiredAttackRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, offsetLoc, speed * Time.deltaTime);
            }
        } 
        else if (transform.position.x <= player.transform.position.x)
        {
            //When player is to the right of the enemy
            offsetLoc.x = transform.position.x - offsetValue;
            Debug.Log("Player is to the right of the enemy");
            if ((player.transform.position.x + transform.position.x) >= desiredAttackRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, offsetLoc, speed * Time.deltaTime); ;
            }
        }
        //Checks to see if the player is within range on either side
        
        
        else
            Shoot();
        
    }

    private void Shoot()
    {
        Debug.Log("Enemy Would shoot");
        //The ranged enemy is gone shoot
    }
}
