using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    bool isBeingHeld = false;
    int ammo = 5;
    [SerializeField] GameObject bullet;
    Rigidbody2D bulletRB;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = bullet.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld && Input.GetKeyDown(KeyCode.C))
        {
            Transform bulletToShoot = Instantiate(bullet.transform, GameObject.Find("Anchor").transform);
            bulletToShoot.transform.SetParent(null);
            Rigidbody2D bulletToShootRB = bulletToShoot.GetComponent<Rigidbody2D>();
            bulletToShootRB.AddForce(Vector2.right * 50, ForceMode2D.Impulse);
        }
    }

    public void setIsBeingHeld()
    {
        isBeingHeld = true;
    }
}
