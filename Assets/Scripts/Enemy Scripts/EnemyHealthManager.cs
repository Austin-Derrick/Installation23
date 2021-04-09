using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    Health health;
    float localHealth;
    Enemy enemy;
    public AudioClip deathSound;
    public AudioSource source;
    //public GameObject EnemyDeathSound;
    
    public void Die()
    {
        //Instantiate(EnemyDeathSound, this.transform.position, this.transform.rotation);
        StartMenu.score += enemy.scoreValue;
        source.Play();
        Invoke("killBug", 0.5f);
        //Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        source.clip = deathSound;
        health = GetComponent<Health>();
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        /*localHealth = health.currentHealth;
        if (localHealth <= 0)
            Die();*/
    }

    public void killBug()
    {
        Destroy(this.gameObject);
    }
}
