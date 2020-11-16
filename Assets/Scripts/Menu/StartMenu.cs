using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public static int score = 0;

    // Start is called before the first frame update
    AudioSource source;
    [SerializeField]
    AudioClip hover;
    [SerializeField]
    AudioClip select;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void GoToFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToEndScreen()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToStartScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public static void addToScore(int val)
    {
        score += val;
    }

    //Audio

    public void PlayHover()
    {
        source.clip = hover;
        source.Play();
    }

    public void PlaySelect()
    {
        source.clip = select;
        source.Play();
    }
}
