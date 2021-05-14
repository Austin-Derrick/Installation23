using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public static int score = 0;
    AudioSource source;
    public AudioClip selectPlay;
    public AudioClip select;
    public AudioClip hover;
    private bool showingCredits = false;
    [SerializeField]
    private Canvas creditsCanvas;
    // Start is called before the first frame update



    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        source = GetComponent<AudioSource>();
    }

    public void GoToFirstLevel()
    {
        if (!FindObjectOfType<AudioManager>().GetComponent<AudioSource>().isPlaying)
        {
            score = 0;
            SceneManager.LoadScene(1);
        }
    }

    public void GoToEndScreen()
    {
        ///SceneManager.LoadScene(2);
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
            source.PlayOneShot(source.clip);
    }

    public void Select()
    {        
            source.clip = select;
            source.PlayOneShot(source.clip);        
    }

    public void SelectPlay()
    {      
            source.clip = selectPlay;
            source.PlayOneShot(source.clip);       
    }
    public void ToggleCredits()
    {
        Debug.Log("Toggling Credits");
        if(!showingCredits)
        {
            showingCredits = true;
            creditsCanvas.enabled = true;
        }
        else
        {
            showingCredits = false;
            creditsCanvas.enabled = false;
        }
    }
}
