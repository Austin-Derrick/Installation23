using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    int health;




    private void Die()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void decreaseHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
}
