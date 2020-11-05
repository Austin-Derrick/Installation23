﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO_LoopAudio : MonoBehaviour
{
    // Start is called before the first frame update

    //AudioSource and AudioClip
    AudioSource source;
    [SerializeField]
    AudioClip clip; 
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clip;
        source.loop = true;
        source.Play();
    }

  
}
