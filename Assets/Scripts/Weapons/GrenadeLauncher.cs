using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    public GameObject grenade;
    public float launchForce;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LaunchGrenade();
        }
    }
    void LaunchGrenade()
    {
        GameObject newGrenade = Instantiate(grenade, firePoint.position, firePoint.rotation);
        newGrenade.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
}
