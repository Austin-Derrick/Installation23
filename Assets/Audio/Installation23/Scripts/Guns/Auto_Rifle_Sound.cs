using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Rifle_Sound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip[] firstShotClip;
    [SerializeField]
    private AudioClip[] autoLoopClip;
    [SerializeField]
    private AudioClip[] finalShotClip;
    [SerializeField]
    private float pitchMin = 1;
    [SerializeField]
    private float pitchMax = 1;

    private bool isShooting;
    private bool newPress = true;
    private bool mouseButtonDown = false;

    //int shotNumber;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseButtonDown = true;
        }

        if (mouseButtonDown)
        {
            if (newPress)
            {
                Debug.Log("New press");
                source.clip = firstShotClip[Random.Range(0, firstShotClip.Length)];
                source.pitch = Random.Range(pitchMin, pitchMax);
                source.Play();
                //isShooting = true;
                newPress = false;
            }
            if (!newPress && !source.isPlaying)
            {
                Debug.Log("isShooting");
                source.clip = autoLoopClip[Random.Range(0, autoLoopClip.Length)];
                source.pitch = Random.Range(pitchMin, pitchMax);
                source.Play();
            }
        }
        if (!mouseButtonDown)
        {

        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseButtonDown = false;
            newPress = true;
            if (newPress)
            {
                Debug.Log("Playing final shot");
                source.pitch = Random.Range(pitchMin, pitchMax);
                source.clip = finalShotClip[Random.Range(0, finalShotClip.Length)];
                source.Play();

            }
        }


    }
}
