using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    bool isBeingHeld = false;
    int ammo = 5;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePosition;
    Rigidbody2D bulletRB;
    float shootForce = 10f;

    public void setIsBeingHeld()
    {
        isBeingHeld = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootBullet(firePosition);
        }
    }
    public void shootBullet(Transform shootPosition)
    {
        GameObject bulletToFire = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation, null);
        bulletRB = bulletToFire.GetComponent<Rigidbody2D>();
        Vector2 bulletDirection = shootPosition.right;
        bulletRB.AddForce(shootForce * bulletDirection, ForceMode2D.Impulse);
    }
}
