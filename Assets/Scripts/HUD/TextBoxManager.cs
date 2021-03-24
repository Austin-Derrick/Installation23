using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;


    public int currentLine = 0;
    public int endAtLine = 0;

    public CharacterController2D[] players;

    public bool isActive;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;

    public Image enterKey;

    // Start is called before the first frame update
    void Start()
    {
        players = FindObjectsOfType<CharacterController2D>();
        if(textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if(isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }

    void Update()
    {

        if(!isActive)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            
            if(!isTyping)
            {
                FindObjectOfType<AudioManager>().Play("Dialogue");
                currentLine++;

                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }

            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }


        }

    }

    private IEnumerator TextScroll (string lineOfText)
    {
        int letter = 0;
        enterKey.enabled = false;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (!cancelTyping && isTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        theText.text = lineOfText;
        enterKey.enabled = true;
        isTyping = false;
        cancelTyping = false;

    }

    public void EnableTextBox()
    {

        textBox.SetActive(true);
        isActive = true;
        for(int i = 0; i >= players.Length - 1; i++)
        {
            players[i].SetSpeedToZero();
            StartCoroutine(TextScroll(textLines[currentLine]));
        }
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        for (int i = 0; i >= players.Length - 1; i++)
        {
            players[i].ReturnSpeedToDefault();
        }
    }

    public void ReloadScript(TextAsset newText)
    {
        if(newText != null)
        {
            textLines = new string[1];

            textLines = (newText.text.Split('\n'));
        }
    }
}
