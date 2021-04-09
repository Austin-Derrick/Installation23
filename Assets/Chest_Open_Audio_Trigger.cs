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
    [SerializeField]
    bool canOpen = false;
    [SerializeField]
    bool hasBeenOpened = false;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        loopsource.clip = LoopClip;
        loopsource.loop = true;
        if (!hasBeenOpened)
            loopsource.Play();
        openSource.clip = OpenClip;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canOpen && !hasBeenOpened && !openSource.isPlaying)
        {
            loopsource.Stop();
            openSource.Play();
            hasBeenOpened = true;
            canOpen = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            canOpen = true;
        }       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canOpen = false;
        }
    }

}
