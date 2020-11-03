using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float speed;
    private Rigidbody2D enemyRb;
    public bool isMelee;
    public bool isRanged;
    public MeleeEnemy meleeEnemyScript;
    public RangedEnemy rangedEnemyScript;
    public float attackRange;
    
    [Space]
    [Header("AI")]
    public bool FoundPlayer;
    public bool goodToAttack = true;
    public GameObject player;

    

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();

        if(meleeEnemyScript == null)
        {
            isRanged = true;
            isMelee = false;
        }
        else
        {
            //rangedEnemyScript.GetSpeed(speed);
            isRanged = false;
            isMelee = true;
        }
    }

    



    // Update is called once per frame
    void Update()
    {

        
        if (FoundPlayer)
        {
            if(!isRanged)
            {
                meleeEnemyScript.MeleeBehavior(player, speed, attackRange, enemyRb);
            }
            else
            {
                rangedEnemyScript.RangedBehavior(player);
                
            }
        }
    }

    public void SetFoundPlayer(bool value, GameObject thePlayer)
    {
        FoundPlayer = value;
        player = thePlayer;
    }

    public IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(1.5f);
        goodToAttack = true;
    }
}
