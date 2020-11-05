using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_PlayOneShot : MonoBehaviour
{
    //This script is meant for playing a gunshot or any sound you really only need to play once
    /// <summary>
    /// How to impliment:
    /// 1. Attach to the item you want to play once. In this case, the sound will only trigger if you press the mouse button 0 down. 
    /// 2. Drag sounds you want to play to array
    /// 
    /// </summary>
    // Start is called before the first frame update
    //Source and Audio Source
    AudioSource source;
    [SerializeField]
    AudioClip [] gunshot;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !source.isPlaying)
        {
            source.clip = gunshot[Random.Range(0, gunshot.Length + 1)];
            source.Play();

        }
    }
}
