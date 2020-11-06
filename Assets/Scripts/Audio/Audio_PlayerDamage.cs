using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_PlayerDamage : MonoBehaviour
{

    /// <summary>
    /// HOW TO IMPLIMENT:
    /// Note: This script should already be attached to a game object. Follow these steps if you need to set it up again. 
    /// 1. Create Empty Object
    /// 2. Add a 2D box collider to the empty game object
    /// 3. Add an audio source to the game object
    /// 4. Attach this script to the object
    /// 5. Drag sound you want to play into the hitSound field. 
    /// </summary>
    //Where the audio plays from
    AudioSource source;
    //The actual audio files (clips)
    [SerializeField]
    AudioClip[] hitSound;
    void Start()
    {
        //Sets the audio source up with the one on the object
        source = GetComponent<AudioSource>();
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if the collision object is the enemy
        if (collision.gameObject.tag == "Enemy")
        {
            //Sets the source clip to the hitSound clips
            source.clip = hitSound[Random.Range(0, hitSound.Length)];
            //Plays the source. 
            source.Play();
        }
    }
}
