using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO_PlayerMovement : MonoBehaviour
{
    //This script plays the sound for characters jumping and footsteps. They will be tied to the animations as function calls as soon as the animations are done. 
    /// <summary>
    /// HOW TO IMPLIMENT: 
    /// 1. Attach to the Player or Create Empty Game Object Under the Player
    /// 2. Set sounds for the jump and footsteps
    /// 3. Set minPitch and maxPitch. Dont worry about setting the regular pitch. 
    /// </summary>
    //Audiosources and Clips
    AudioSource source;
    [SerializeField]
    AudioSource jumpSource;
    [SerializeField]
    AudioClip[] gravelStep;
    [SerializeField]
    AudioClip jump;
    [SerializeField]
    AudioClip[] metalStep;
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
    string material;
    CharacterController2D characterController;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController2D>();
        material = "gravel";
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
        if (!source.isPlaying && material == "gravel" && characterController.grounded)
        {
            Debug.Log("In Footsteps");
            source.clip = gravelStep[Random.Range(0, gravelStep.Length)];
            pitch = Random.Range(minPitch, maxPitch);
            source.pitch = pitch;
            source.volume = volume;
            source.Play();
        }
        else if (!source.isPlaying && material == "metal" && characterController.grounded)
        {
            Debug.Log("In Footsteps");
            source.clip = metalStep[Random.Range(0, metalStep.Length)];
            pitch = Random.Range(minPitch, maxPitch);
            source.pitch = pitch;
            source.volume = volume;
            source.Play();
        }
    }

    void jumps()
    {
        if (!jumpSource.isPlaying && characterController.grounded)
        {
            jumpSource.clip = jump;
            pitch = Random.Range(minPitch, maxPitch);
            jumpSource.pitch = pitch;
            jumpSource.Play();
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
        if (collision.gameObject.tag == "FootstepMetal")
        {
            material = "gravel";
        }
    }
}
