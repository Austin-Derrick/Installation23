using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO_PickUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    //Source and Audioclips
    AudioSource source;
    [SerializeField]
    AudioClip clip;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            source.clip = clip;
            source.Play();
        }
    }
}
