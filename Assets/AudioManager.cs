﻿using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
        }
    }
    private void Start()
    {
        Play("Theme");
        Play("Ambience");
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Play();

        //Footsteps
        if (s.name == "Gravel Footstep")
        {
            s.volume = UnityEngine.Random.Range(.7f, 1f);
            s.pitch = UnityEngine.Random.Range(.8f, 1.2f);
            s.source.Play();
        }
        if (s.name == "Metal Footstep")
        {
            s.volume = UnityEngine.Random.Range(.7f, 1f);
            s.pitch = UnityEngine.Random.Range(.8f, 1.2f);
            s.source.Play();
        }


    }
}
