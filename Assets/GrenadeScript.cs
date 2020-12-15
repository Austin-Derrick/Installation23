using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    [SerializeField]
    private float fuseTime;

    private float currentTime;

    private float timeToExplode;

    [SerializeField]
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        timeToExplode = Time.time + fuseTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeToExplode)
        {
            
        }
    }

    private void Explode()
    {

    }
}
