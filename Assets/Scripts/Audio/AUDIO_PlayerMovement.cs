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
      
    }

    void footsteps()
    {
        if (!source.isPlaying && controller.grounded && material == "gravel")
        {
            source.clip = gravelStep[Random.Range(0, gravelStep.Length)];
            source.pitch = Random.Range(minPitch, maxPitch);
            source.volume = Random.Range(.8f, 1f);
            source.PlayOneShot(source.clip);
        }
        if (!source.isPlaying && controller.grounded && material == "metal")
        {
            source.clip = metalStep[Random.Range(0, metalStep.Length)];
            source.pitch = Random.Range(minPitch, maxPitch);
            source.volume = Random.Range(.8f, 1f);
            source.PlayOneShot(source.clip);
        }
    }
    public void jumps()
    {
        if (!jumpSource.isPlaying && controller.grounded)
        {
            jumpSource.clip = jump;
            jumpSource.pitch = Random.Range(minPitch, maxPitch);
            jumpSource.volume = Random.Range(.8f, 1f);
            jumpSource.PlayOneShot(jumpSource.clip);
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
            FindObjectOfType<AudioManager>().Play("Pick Up");
        }
    }
}
