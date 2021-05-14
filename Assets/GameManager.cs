using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private TextMesh score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(score != null)
        {
            score.text = StartMenu.score.ToString();
        }
    }

    public void GameOver()
    {
        Debug.Log("Should be ending game");
        SceneManager.LoadScene(2);
    }
}
