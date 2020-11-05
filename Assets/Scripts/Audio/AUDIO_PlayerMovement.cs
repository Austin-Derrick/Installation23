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
    float minPitch = 1.0f;
    [SerializeField]
    float maxPitch = 1.0f;
    [SerializeField]
    float pitch;
    [Range(0, 1)]
    [SerializeField]
    float volume = 1.0f;
    bool walking = false;
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
            walking = true;
            
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            walking = false;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            walking = false;
            jumps();
        }
        if (walking) 
        {
            footsteps();
        }
    }

    void footsteps()
    {
        if (!source.isPlaying)
        {
            Debug.Log("In Footsteps");
            source.clip = step[Random.Range(0, step.Length)];
            pitch = Random.Range(minPitch, maxPitch);
            source.pitch = pitch;
            source.volume = volume;
            source.Play();
        }
    }

    void jumps()
    {
        if (!source.isPlaying)
        {
            source.clip = jump;
            pitch = Random.Range(minPitch, maxPitch);
            source.pitch = pitch;
            source.volume = volume;
            source.Play();
        }
    }
}
