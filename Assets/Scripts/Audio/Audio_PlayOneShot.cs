using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_PlayOneShot : MonoBehaviour
{
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
