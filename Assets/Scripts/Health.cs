﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Collider2D entityCollider;
    private Rigidbody2D entityRb;

    [Header("Attributes")]
    public float maxHealth = 100;
    public float armor = 30;
    public float currentHealth = 100;

    [Space]
    [Header("Misc")]
    public float damageBounceBack = 10;

    // Start is called before the first frame update
    void Start()
    {
        entityRb = GetComponent<Rigidbody2D>();
        entityCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            if(gameObject.CompareTag("Player"))
            {
                //Game Over, or whatever we decide on death
            }
            else if (gameObject.CompareTag("Enemy"))
            {
                //Kills enemy if they run out of heatlh, maybe we can have a death animation set up here
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Bullet")
        {
            BounceBack(collision);
        }
        if (collision.gameObject.CompareTag("Player") && !gameObject.CompareTag("Player"))
        {
            BounceBack(collision);
        }
        if(collision.gameObject.CompareTag("Enemy") && !gameObject.CompareTag("Enemy"))
        {
            float enemyHealth = collision.gameObject.GetComponent<Health>().maxHealth;
            TakeDamage(enemyHealth * .1f);
            BounceBack(collision);
        }
    }

    //Formula for taking damage is stored here, can be called from anywhere with base damage value being passed into it
    public void TakeDamage(float damage)
    {
        //Temp formula for armor damage reduction, provides 50% armor reduction at 50 armor stat and provides diminishing returns above.
        currentHealth = currentHealth - (damage - ((damage * (armor / (armor + 50)))));
    }

    private void BounceBack(Collision2D collision)
    {
        //Checks to see where the player is in reference to the object they collided with, then pushes them in the opposite direction
        if (transform.position.x < collision.gameObject.transform.position.x)
        {
            entityRb.velocity = Vector2.left * damageBounceBack;
        }
        else
        {
            entityRb.velocity = Vector2.right * damageBounceBack;
        }
    }


}