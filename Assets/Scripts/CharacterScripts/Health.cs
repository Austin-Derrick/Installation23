﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Collider2D entityCollider;
    private Rigidbody2D entityRb;
    public Damagable damagable;
    public GameManager gameManager;
    public SpriteRenderer sprite;

    [Header("Attributes")]
    public float maxHealth = 100;
    public float armor = 30;
    public float currentHealth = 100;

    [Space]
    [Header("Misc")]
    public float damageBounceBack = 10;
    public Slider healthBar;
    
    [Space]
    [Header("Sound")]
    AudioSource source;
    AudioClip [] audDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        damagable = GetComponent<Damagable>();
        entityRb = GetComponent<Rigidbody2D>();
        entityCollider = GetComponent<Collider2D>();
        source = GetComponent<AudioSource>();
        if(healthBar != null)
        {
            healthBar.minValue = 0;
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

        damagable.OnDamaged += TakeDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth <=0 )
        {
            if(gameObject.CompareTag("Player"))
            {
                currentHealth = 0;
                gameManager.GameOver();
            }
            if(gameObject.CompareTag("Enemy"))
            {
                entityCollider.enabled = false;
                if(sprite != null)
                {
                    sprite.enabled = false;
                }
            }
        }
        if(healthBar != null)
            healthBar.value = currentHealth;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {       
        if(collision.gameObject.CompareTag("HealthPot") && gameObject.CompareTag("Player"))
        {
            currentHealth += (maxHealth * .05f);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy"))
        {
            //BounceBack(collision);
        }
        if(collision.gameObject.CompareTag("Enemy") && !gameObject.CompareTag("Enemy"))
        {
            float enemyHealth = collision.gameObject.GetComponent<Health>().maxHealth;
            TakeDamage(enemyHealth * .3f);
            //BounceBack(collision);
        }
    }

    //Formula for taking damage is stored here, can be called from anywhere with base damage value being passed into it
    public void TakeDamage(float damage)
    {
        //Temp formula for armor damage reduction, provides 50% armor reduction at 50 armor stat and provides diminishing returns above.
        currentHealth = currentHealth - (damage - ((damage * (armor / (armor + 50)))));
        if (currentHealth <= 0)
        {
            GetComponent<EnemyHealthManager>().Die();
        }
        //if(source.clip != null)
        //    source.clip = audDamage[Random.Range(0, audDamage.Length)];
        //source.Play();

        
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