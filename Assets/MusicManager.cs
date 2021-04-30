using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    AudioClip music;
    AudioSource source01;

    private void Start()
    {
        source01 = GetComponent<AudioSource>();
        source01.clip = music;
        source01.loop = true;
        source01.Play();
    }

}
