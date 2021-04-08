using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    Health health;
    float localHealth;
    Enemy enemy;
    public GameObject EnemyDeathSound;
    
    private void Die()
    {
       
        Instantiate(EnemyDeathSound, this.transform.position, this.transform.rotation);
        StartMenu.score += enemy.scoreValue;
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        localHealth = health.currentHealth;
        if (localHealth <= 0)
            Die();
    }
}
