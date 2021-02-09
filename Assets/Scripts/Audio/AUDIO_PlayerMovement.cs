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
            FindObjectOfType<AudioManager>().Play("Gravel Footstep");
        }
        if (!source.isPlaying && controller.grounded && material == "metal")
        {
            FindObjectOfType<AudioManager>().Play("Metal Footstep");
        }
    }
    public void jumps()
    {
        if (!jumpSource.isPlaying && controller.grounded)
        {
            FindObjectOfType<AudioManager>().Play("Jump");
        }
    }

    public void PlayPickUp()
    {
        if (!pickUpSource.isPlaying)
        {
            FindObjectOfType<AudioManager>().Play("Pick Up");
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
