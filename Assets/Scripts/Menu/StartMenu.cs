using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
