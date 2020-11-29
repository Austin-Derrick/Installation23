using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO_PlayerMovement : MonoBehaviour
{
    //This script plays the sound for character interactions and movement.
    /// <summary>
   
    //Audiosources and Clips
    //Footsteps
    AudioSource source;
    [SerializeField]
    AudioClip[] gravelStep;
    [SerializeField]
    AudioClip[] metalStep;
    //Jump
    [SerializeField]
    AudioSource jumpSource;
   [SerializeField]
    AudioClip jump;
    //PickUp
    [SerializeField]
    AudioSource pickUpSource;
    [SerializeField]
    AudioClip pickupSound;


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
    string material = "gravel";
    CharacterController2D controller;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
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
        }*///
    }

    void footsteps()
    {
        if (!source.isPlaying && controller.grounded && material == "gravel")
        {
            source.clip = gravelStep[Random.Range(0, gravelStep.Length)];
            pitch = Random.Range(minPitch, maxPitch);
            source.pitch = pitch;
            source.volume = volume;
            source.Play();
        }
        if (!source.isPlaying && controller.grounded && material == "metal")
        {
            source.clip = metalStep[Random.Range(0, metalStep.Length)];
            pitch = Random.Range(minPitch, maxPitch);
            source.pitch = pitch;
            source.volume = volume;
            source.Play();
        }
    }
    public void jumps()
    {
        if (!jumpSource.isPlaying && controller.grounded)
        {
            Debug.Log("Jump initiatied");
            jumpSource.clip = jump;
            pitch = Random.Range(minPitch, maxPitch);
            jumpSource.pitch = pitch;
            jumpSource.volume = volume;
            jumpSource.Play();
            Debug.Log("Jump Played");
        }
    }

    public void PlayPickUp()
    {
        if (!pickUpSource.isPlaying)
        {
            pickUpSource.clip = pickupSound;
            pitch = Random.Range(minPitch, maxPitch);
            pickUpSource.pitch = pitch;
            pickUpSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "FootstepMetal")
        {
            material = "metal";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "FootstepMetal")
        {
            material = "gravel";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            PlayPickUp();
        }
    }
}
