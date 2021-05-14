using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class DisplayFinalScore : MonoBehaviour
{
    [SerializeField]
    private GameObject textObject;
    private TMP_Text scoreTextComp;
    // Start is called before the first frame update
    void Start()
    {
        scoreTextComp = textObject.GetComponent<TMP_Text>();
        int score = StartMenu.score;
        scoreTextComp.text = "Final Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
