using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length;
    private float startPos;
    public GameObject player;
    public float parallaxEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //How far we've moved relative to player
        float temp = (player.transform.position.x * (1 - parallaxEffect));

        //Determines distance the parallax has travelled
        float dist = (player.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, (player.transform.position.y - 5), transform.position.z);

        //Keeps background repeating.
        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;
    }
    private void Update()
    {
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
