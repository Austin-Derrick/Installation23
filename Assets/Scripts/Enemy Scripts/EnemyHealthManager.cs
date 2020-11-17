using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    float localHealth;
    public Health health;
    public Enemy enemy;



    private void Die()
    {
        //Play death sound here

        //Adds score to the player score based off of the value of the enemy set in the script of same name.
        StartMenu.addToScore(enemy.scoreValue);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        localHealth = health.currentHealth;
        if (localHealth <= 0)
        {
            Die();
        }
    }
}
