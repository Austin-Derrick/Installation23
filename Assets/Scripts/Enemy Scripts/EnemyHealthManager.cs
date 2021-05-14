using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    Health health;
    float localHealth;
    Enemy enemy;
    public AudioClip[] deathSound;
    public AudioSource source;
    public GameObject healthPickup;
    public GameObject splatEffect;
    //public GameObject EnemyDeathSound;
    

    public void Die()
    {        
        //Instantiate(EnemyDeathSound, this.transform.position, this.transform.rotation);
        StartMenu.score += enemy.scoreValue;
        int num = Random.Range(0, 2);
        for (int i = 0; i <= num; i++)
        {
            Instantiate(healthPickup, enemy.transform.position, enemy.transform.rotation,gameObject.transform.parent.gameObject.transform);
            
        }
        Vector3 splatAngle = new Vector3(-90, 0, 0);
        Instantiate(splatEffect, enemy.transform.position, Quaternion.Euler(splatAngle));
        source.PlayOneShot(source.clip);
        Debug.Log("Playing DeathSound");
        Invoke("killBug", 2f);
        
        //Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        source.clip = deathSound[Random.Range(0, deathSound.Length)];
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
