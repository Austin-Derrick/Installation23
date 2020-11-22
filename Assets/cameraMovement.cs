﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float smoothing;

    [SerializeField]
    private float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            /*
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 pp = new Vector3(target.position.x, target.position.y, target.position.z);
            
            Vector3 targetPosition = new Vector3((mp.x + pp.x) / 2, (mp.y + pp.y) / 2, -10);

            Vector3 differenceVector = mp - pp;

            if (differenceVector.x > maxDistance + pp.x)
            {
                transform.position = new Vector3(maxDistance + pp.x, differenceVector.y, -10);
                //Vector3 maxVector = (mp - pp);
                //maxVector.Normalize();
                //maxVector = (maxVector / 2) * maxDistance;
                //targetPosition = maxVector;
            }
            else if (differenceVector.y > maxDistance + pp.y)
            {
                transform.position = new Vector3(differenceVector.x, maxDistance + pp.y, -10);

                //    Vector3 maxVector = (mp - pp);
                //    maxVector.Normalize();
                //    maxVector = (maxVector/2) *maxDistance;
                //    targetPosition = maxVector;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);

            }
            */
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}