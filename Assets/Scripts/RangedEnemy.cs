using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public float offsetVal = 5.0f;
    private bool isActive = false;
    private bool isSafe = true;
    public float speed = 0;
    public CircleCollider2D safetyBubble;
    Vector2 MoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if(isSafe)
            Shoot();
        else
            StartCoroutine(MaintainDistance(speed, player));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(CompareTag("Player"))
            isSafe = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
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
        
        transform.position = Vector2.MoveTowards(transform.position, MoveDirection, speed * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
    }

    private void Shoot()
    {
        //The ranged enemy is gone shoot
    }
}
