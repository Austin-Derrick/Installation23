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

    [SerializeField]
    Enemy[] enemy;

    public AudioMixerSnapshot CombatMusic;
    public AudioMixerSnapshot NormalMusic;

    private GameObject player;
    private CapsuleCollider2D capCollider;
    private bool isPlayingCombatMusic;
    [SerializeField]
    private float detectionRadius;


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
        enemy = FindObjectsOfType<Enemy>();

        if(enemy.Length > 0)
        {
            SwitchToCombatMusic();
        }
        else
        {
            SwitchToNormalMusic();
        }
        //for (int i = 0; i < enemy.Length; i++)
        //{
        //    if (enemy[i].isActiveAndEnabled)
        //    {
        //        source02.clip = combatMusic;
        //        source02.loop = true;
        //        source02.Play();
        //        CombatMusic.TransitionTo(1f);
        //    }
        //}
        //else
        //{
        //    NormalMusic.TransitionTo(1f);
        //}
    }
    private void SwitchToCombatMusic()
    {       
        CombatMusic.TransitionTo(1f);
    }
    private void SwitchToNormalMusic()
    {
        NormalMusic.TransitionTo(1f);
    }
}
