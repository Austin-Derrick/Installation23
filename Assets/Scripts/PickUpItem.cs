using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform anchor;
    [SerializeField] ShootBullet shootBulletScript;

    private void Start()
    {
        anchor = transform.GetChild(2);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            collision.transform.position = anchor.position;
            shootBulletScript.setIsBeingHeld();
            collision.gameObject.transform.SetParent(anchor);

        }
    }
}
