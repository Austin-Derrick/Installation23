using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Sound_Script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip clip;
    AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        StartCoroutine(Wait());
        Debug.Log("Waiting");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(this.gameObject);
    }
}
