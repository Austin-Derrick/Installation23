using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private BoxCollider2D interactBox;

    private bool lookingAtInteractible;

    private GameObject currentInteractible;

    public delegate void InteractedWith();
    public static event InteractedWith OnInteract;
    // Start is called before the first frame update
    void Start()
    {
        interactBox = GetComponentInParent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lookingAtInteractible && Input.GetKeyDown(KeyCode.E))
        {
            if (OnInteract != null)
            {
                OnInteract();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Interactive"))
        {
            lookingAtInteractible = true;
            currentInteractible = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        lookingAtInteractible = false;
        currentInteractible = null;
    }
}
