using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    AudioClip normalMusic;
    [SerializeField]
    AudioClip combatMusic;
    AudioSource source01;
    [SerializeField]
    AudioSource source02;
    DetectPlayer[] detectPlayer;
    public AudioMixerSnapshot CombatMusic;
    public AudioMixerSnapshot NormalMusic;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        source01 = GetComponent<AudioSource>();
        source01.clip = normalMusic;
        source01.loop = true;
        source01.Play();
        source02.clip = combatMusic;
        source02.loop = true;
        source02.Play();
    }

    private void Update()
    {
        detectPlayer = FindObjectsOfType<DetectPlayer>();
        for(int i = 0; i < detectPlayer.Length; i++)
        {
            if (detectPlayer[i].hasFoundPlayer)
            {
                CombatMusic.TransitionTo(1f);
            }
        }
        if(detectPlayer.Length == 0)
        {
            NormalMusic.TransitionTo(1f);
        }
    }

}
