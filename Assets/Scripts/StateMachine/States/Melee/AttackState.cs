using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private Enemy _enemy;
    GameObject player;

    float distanceToPlayer;
    float count = 0.5f;
    float waitTime = 0.5f;
    public AttackState(Enemy enemy) : base(enemy.gameObject)
    {
        _enemy = enemy;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override Type Tick()
    {
        distanceToPlayer = Vector3.Distance(_enemy.gameObject.transform.position, player.transform.position);

        if (distanceToPlayer > 1.6f)
        {
            Debug.Log("Chase");
            count = 0.5f;
            return typeof(ChaseState);
        }
        else
        {
            if (count >= waitTime)
            {
                if (Mathf.Abs(distanceToPlayer) < 1)
                {
                    Debug.Log("Swipe Attack");
                }
                else
                {
                    Debug.Log("Lunge Attack");
                    _enemy.Attack(distanceToPlayer);
                }
                count = 0;
            }
            else
            {
                count += Time.deltaTime;
            }

        }

        return typeof(AttackState);
    }
}
