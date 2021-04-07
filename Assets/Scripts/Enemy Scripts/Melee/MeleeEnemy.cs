using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [Header("AI")]

    [Space]
    [Header("Jump Variables")]
    public float jumpHeight;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float checkRadius;

    StateMachine stateMachine => GetComponent<StateMachine>();
    public Transform Target { get; private set; }
    public bool isGrounded = true;
    Transform FloorCheck;
    public GameObject _player;
    BoxCollider2D collider => GetComponent<BoxCollider2D>();

    private void Awake()
    {
        InitializeStateMachine();
        FloorCheck = transform.GetChild(2);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(FloorCheck.position, new Vector2(collider.size.x - 0.1f, 0.15f), 0, groundLayer);
    }

    public override void Attack(float distance)
    {
        if (isGrounded)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(distance, 5), ForceMode2D.Impulse);
            Debug.Log("Pounce");
            // Decrease Player health
        }
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


}
