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
        Debug.Log("Set");
        _enemy = enemy;
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Debug.Log("Set player");

        }
        if (_enemy != null)
        {
            Debug.Log("Set enemy");

        }
    }

    public override Type Tick()
    {
        distanceToPlayer = Vector3.Distance(_enemy.transform.position, player.transform.position);
        if (distanceToPlayer < 1.5f)
        {
            Debug.Log("Attack");
            return typeof(AttackState);
        }
        else if (distanceToPlayer > 7)
        {
            Debug.Log("Patrol");
            return typeof(PatrolState);
        }
        else
        {
            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, player.transform.position, 0.02f);
            return typeof(ChaseState);
        }
    }
}
