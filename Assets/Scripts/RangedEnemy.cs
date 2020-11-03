using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public float offsetVal = 4.0f;
    private bool isActive = false;
    private bool isSafe;
    public float speed = 0;
    Vector2 MoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        isSafe = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetSpeed(float Speed)
    {
        speed = Speed;
    }

    //public void SetActive(bool status)
    //{

    //}

    public void RangedBehavior(GameObject player)
    {
        CheckForSafety(player);
        if(isSafe)
            Shoot();
        else
            StartCoroutine(MaintainDistance(speed, player));
    }

    private void CheckForSafety(GameObject player)
    {
        if ((player.transform.position.x - transform.position.x) < offsetVal)
            isSafe = false;
        else
            isSafe = true;
    }

    //When the player gets too close to the enemy, the enemy walks away from the player
    IEnumerator MaintainDistance(float speed, GameObject player)
    {
        if(transform.position.x < player.transform.position.x)
        {
            
            MoveDirection.x = transform.position.x - offsetVal;
        }
        else
        {
            
            MoveDirection.x = transform.position.x + offsetVal;
        }
        MoveDirection.y = 0.0f;
        Debug.Log("Move Direction is x: " + MoveDirection.x + " y: " + MoveDirection.y);
        transform.position = Vector2.MoveTowards(transform.position, MoveDirection, speed * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
    }

    private void Shoot()
    {
        //The ranged enemy is gone shoot
    }
}
