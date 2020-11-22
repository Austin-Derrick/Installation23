using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateScore : MonoBehaviour
{
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        if (SceneManager.GetActiveScene().buildIndex == 1)
            score.text = ("Score:  " + StartMenu.score.ToString());
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (score != null)
    //        score.text = "Score: " + StartMenu.score.ToString();
    //    else
    //        score.text = "Score: " + 0;
    //}
}
