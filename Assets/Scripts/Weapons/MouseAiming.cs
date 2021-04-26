using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseAiming : MonoBehaviour
{
    Vector3 mousePos;
    [SerializeField]
    Transform target;
    Vector3 objectPos;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 5.23f; //The distance between the camera and object
        objectPos = Camera.main.WorldToScreenPoint(target.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3 (0, 0, angle));
    }
}
