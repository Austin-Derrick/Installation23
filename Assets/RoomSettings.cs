using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSettings : MonoBehaviour
{
    GameObject mainCam;
    public cameraMovement camScript;

    [SerializeField]
    float leftLimit;

    [SerializeField]
    float rightLimit;

    [SerializeField]
    float topLimit;

    [SerializeField]
    float bottomLimit;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        mainCam.transform.parent = gameObject.transform;
        camScript = GetComponentInChildren<cameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OutputData()
    {

    }
}
