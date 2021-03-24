using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtline : MonoBehaviour
{
    public TextAsset theText;

    public GameObject rightMousePrompt;

    public int startLine = 0;
    public int endLine;

    public TextBoxManager textBox;
    public bool destroyWhenActivated;

    public bool requireButtonPress;
    private bool waitForPress;

    // Start is called before the first frame update
    void Start()
    {
        textBox = FindObjectOfType<TextBoxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.Mouse1))
        {

            //These are the actual lines that update the text in the textbox manager
            textBox.ReloadScript(theText);
            textBox.currentLine = startLine;
            textBox.endAtLine = endLine;
            textBox.EnableTextBox();


            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
            
            
        }

        
        
        
    }

    //From here, you would put your trigger type. OnTriggerEnter, OnCollisionEnter, on mouse down, etc etc.
    //Example function
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player"))
        {
            if(requireButtonPress)
            {
                rightMousePrompt.SetActive(true);
                waitForPress = true;
                return;
            }

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rightMousePrompt.SetActive(false);
            waitForPress = false;
        }
    }
}
