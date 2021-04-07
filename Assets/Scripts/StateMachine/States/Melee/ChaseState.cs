using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    private Enemy _enemy;

    GameObject player;
    float distanceToPlayer;
    float tempDistance = 1f;
    float speed = 2f;
    float rayDistance = 10;

    public ChaseState(Enemy enemy) : base(enemy.gameObject)
    {
        
        _enemy = enemy;
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            

        }
        if (_enemy != null)
        {
            

        }
    }

    public override Type Tick()
    {
        distanceToPlayer = Vector3.Distance(_enemy.transform.position, player.transform.position);
        if (distanceToPlayer < 1.5f)
        {
            return typeof(AttackState);
        }
        else if (distanceToPlayer > 7)
        {
            
            return typeof(PatrolState);
        }
        else
        {
            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, player.transform.position, 0.02f);
            if (player.transform.position.y > _enemy.transform.position.y + 3)
            {
                _enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(Vector2.Distance(_enemy.transform.position, player.transform.position), 5), ForceMode2D.Impulse);
                return typeof(ChaseState);
            }
            return typeof(ChaseState);
        }
    }
}
