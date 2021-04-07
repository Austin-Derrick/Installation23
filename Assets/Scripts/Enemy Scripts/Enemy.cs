using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float speed;
    private Rigidbody2D RB;
    public float attackRange;
    public int scoreValue;

    [Space]
    [Header("AI")]
    public GameObject player;

    public virtual void Attack(float distance)
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
