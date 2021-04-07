using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    StateMachine stateMachine => GetComponent<StateMachine>();


    public float offsetVal = 4.0f;
    Vector2 MoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        InitializeStateMachine();
    }

    void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(PatrolState), new PatrolState(this)},
            { typeof(ChaseState), new ChaseState(this)},
            { typeof(AttackState), new AttackState(this)}
        };

        stateMachine.SetStates(states);
    }

    #region OLD
    public void RangedBehavior(GameObject player)
    {
        CheckForSafety(player);
        Shoot();
        StartCoroutine(MaintainDistance(speed, player));
    }

    private void CheckForSafety(GameObject player)
    {
        //if ((player.transform.position.x - transform.position.x) < offsetVal)
    }

    //When the player gets too close to the enemy, the enemy walks away from the player
    IEnumerator MaintainDistance(float speed, GameObject player)
    {
        if(transform.position.x < player.transform.position.x)
        {
            
            MoveDirection.x = transform.position.x - offsetVal;
        }
        else
        {
            
            MoveDirection.x = transform.position.x + offsetVal;
        }
        MoveDirection.y = 0.0f;
        Debug.Log("Move Direction is x: " + MoveDirection.x + " y: " + MoveDirection.y);
        transform.position = Vector2.MoveTowards(transform.position, MoveDirection, speed * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
    }

    private void Shoot()
    {
        //The ranged enemy is gone shoot
    }
    #endregion  
}
