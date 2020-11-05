using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO_PlayerMovement : MonoBehaviour
{
    //This script plays the sound for characters jumping and footsteps. They will be tied to the animations as function calls as soon as the animations are done. 
    //Audiosources and Clips
    AudioSource source;
    [SerializeField]
    AudioClip[] step;
    [SerializeField]
    AudioClip jump;
    //Variables
    [SerializeField]
    float minPitch;
    [SerializeField]
    float maxPitch;
    [SerializeField]
    float pitch;
    [Range(0, 1)]
    [SerializeField]
    float volume = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            footsteps();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumps();
        }
    }

    void footsteps()
    {
        source.clip = step[Random.Range(0, step.Length)];
        pitch = Random.Range(minPitch, maxPitch);
        source.pitch = pitch;
        source.volume = volume;
        source.Play();
    }

    void jumps()
    {
        source.clip = jump;
        pitch = Random.Range(minPitch, maxPitch);
        source.pitch = pitch;
        source.volume = volume;
        source.Play();
    }
}
