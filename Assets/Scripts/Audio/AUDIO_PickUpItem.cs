using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO_PickUpItem : MonoBehaviour
{
    //This script is for playing a sound when the player picks up the object. 
    

    /// <summary>
    /// HOW TO IMPLIMENT: 
    /// 1. Attach script to the item that is going to be picked up
    /// 2. Set what audio clip you want to play when the player picks it up 
    /// </summary>
    /// 


    //Source and Audioclips

    //Where the audio plays
    AudioSource source;
    [SerializeField]
    //The actual sound files
    AudioClip clip;
    void Start()
    {
        //Gets the source component from the object the script is attached to. 
        source = GetComponent<AudioSource>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if the colliding object is the player
        if(collision.gameObject.tag == "Player")
        {
            //Sets the source to play what the sound file in the clip is
            source.clip = clip;
            //Plays the file. 
            source.Play();
        }
    }
}
