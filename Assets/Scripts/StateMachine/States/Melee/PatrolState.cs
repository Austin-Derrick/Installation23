using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    private Enemy _enemy;

    #region Ground and Wall Check
    private Transform groundCheckPoint;
    private Transform wallCheckPoint;

    private bool groundCheck;
    private bool wallCheck;
    float circleRadius;

    LayerMask groundLayer;
    #endregion

    float moveSpeed = 2.5f;
    private float moveDirection = 1f;

    private bool facingRight = true;

    float rayDistance = 5f;

    

    public PatrolState(Enemy enemy) : base(enemy.gameObject)
    {
        _enemy = enemy;
        wallCheckPoint = enemy.transform.GetChild(0);
        groundCheckPoint = enemy.transform.GetChild(1);
        groundLayer = LayerMask.GetMask("Ground");
        circleRadius = 0.5f;
        
    }

    public override Type Tick()
    {
        groundCheck = Physics2D.OverlapCircle(groundCheckPoint.position, circleRadius, groundLayer);
        wallCheck = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, groundLayer);
        Ray ray = new Ray(_enemy.transform.position + new Vector3(2, 0), Vector3.right);
        RaycastHit2D hit = Physics2D.Raycast(wallCheckPoint.position, _enemy.transform.right * rayDistance, rayDistance);
        Debug.DrawRay(wallCheckPoint.position, _enemy.transform.right * rayDistance, Color.red, 0.5f);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                Debug.Log("Chase");
                return typeof(ChaseState);
            }
            else if (hit.collider.tag == "Enemy")
            {
                Flip();
            }
            else
            {
                Debug.Log($"{hit.collider.gameObject.name}");
            }
        }

        if (wallCheck || !groundCheck)
        {
            Flip();

        }
        else
        {
            _enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * moveDirection, _enemy.GetComponent<Rigidbody2D>().velocity.y);
        }

        return typeof(PatrolState);
    }

    private void Flip()
    {
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
