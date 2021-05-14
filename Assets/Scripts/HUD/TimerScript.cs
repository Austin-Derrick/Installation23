using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    [SerializeField]
    public GameObject score;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        timeText.color = new Color(255, 255, 255);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

                Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(2);
                SceneManager.LoadScene(2);
                SceneManager.MoveGameObjectToScene(score, sceneToLoad);
            }
            if(timeRemaining < 60)
            {
                timeText.color = new Color(245, 33, 0);
            }
            if (timeRemaining < 30)
                timeText.color = new Color(250, 0, 0);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

