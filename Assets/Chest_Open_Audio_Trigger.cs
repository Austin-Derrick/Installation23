using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Open_Audio_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip LoopClip;
    public AudioClip OpenClip;
    public AudioSource loopsource;
    public AudioSource openSource;
    bool canOpen = false;
    void Start()
    {
        loopsource.clip = LoopClip;
        loopsource.loop = true;
        loopsource.Play();
        openSource.clip = OpenClip;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canOpen && !openSource.isPlaying)
        {
            loopsource.Stop();
            openSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canOpen = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canOpen = false;
    }
}
