using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO_LoopAudio : MonoBehaviour
{
   

    //This script is meant to play music and ambient sounds
/// <summary>
/// HOW TO IMPLIMENT:
/// 1. Create Empty Game Object
/// 2. Attach Script to Game Object
/// 3. Drag music clip to the clip field inside of the object. 
/// </summary>


    //AudioSource and AudioClip

    //Where the AudioClip Plays From
    AudioSource source;
    //The actual clips of audio. 
    [SerializeField]
    AudioClip clip; 
    void Start()
    {
        //Get source component from object
        source = GetComponent<AudioSource>();
        //Set source clip to play what ever clip is in the clip field.
        source.clip = clip;
        //Set the source to loop the clip indefinitely
        source.loop = true;
        //Play the clip. 
        source.Play();
    }

  
}
