using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponents : MonoBehaviour
{
    public new BoxCollider2D collider { get; private set; }
    public Rigidbody2D rigidBody { get; private set; }

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        if (GetComponent<Rigidbody2D>() == null)
        {

        }
        else
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }
    }
}
