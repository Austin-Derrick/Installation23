using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    Health health;
    float localHealth;
    Enemy enemy;

    private void Die()
    {
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
