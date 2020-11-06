using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst_Rifle_Sound : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource source;
    [SerializeField]
    private AudioClip[] burstShots;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !source.isPlaying)
        {
            source.clip = burstShots[Random.Range(0, burstShots.Length)];
            source.Play();
        }
    }
}
