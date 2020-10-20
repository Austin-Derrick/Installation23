using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    private GameObject player;
    public bool goodToAttack = true;
    Enemy enemy;
    RaycastHit2D hit;
    public Collider2D detectionRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int nonPlayer = 1 << 9;
        nonPlayer = ~nonPlayer;
        Debug.DrawLine(transform.position, collision.gameObject.transform.position, Color.red);
        //Checks to see if the player is within range of the enemy AI
        hit = Physics2D.Raycast(transform.position, collision.gameObject.transform.position, nonPlayer);
        if (hit && goodToAttack)
        {
            enemy.SetFoundPlayer(true, collision.gameObject);
        }
    }


}
