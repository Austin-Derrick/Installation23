using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        waitTime = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
                Invoke("ResetRotation", 0.3f);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }        
    }
    void ResetRotation()
    {
        effector.rotationalOffset = 0f;
    }
}
