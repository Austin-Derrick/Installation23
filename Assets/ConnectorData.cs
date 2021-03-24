using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorData : MonoBehaviour
{
    [SerializeField]
    public bool isRight;

    public GameObject connectedRoom;
    public GameObject linkedConnector;
    public bool roomSpawned = false;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    public GameObject ConnectedRoom
    {
        get
        {
            return connectedRoom;
        }
        set
        {

        }
    }
    public bool IsRight
    {
        get
        {
            return isRight;
        }
        set
        {

        }
    }
}
