using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    [SerializeField]
    private float roomSize;

    [SerializeField]
    public List<GameObject> entrances = new List<GameObject>();

    [SerializeField]
    private bool canBeFlipped;

    [SerializeField]
    private BoxCollider2D roomSizeCollider;

    private CompositeCollider2D compCollider;

    public GameObject usedEntrance;
    

    // Start is called before the first frame update
    void Start()
    {
        compCollider = GetComponentInChildren<CompositeCollider2D>();
        Debug.Log(compCollider.bounds);
        roomSizeCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void FlipSide()
    {
        for(int element = 0; element < entrances.Count; element++)
        {
            ConnectorData thisConnectorData = entrances[element].GetComponent<ConnectorData>();
            if (thisConnectorData.isRight)
            {
                thisConnectorData.isRight = false;
            }
            else
                thisConnectorData.isRight = true;
        }
    }
    public float RoomSize
    {
        get
        {
            return roomSize;
        }
        set
        {
            roomSize = value;
        }
    }
    public bool CanBeFlipped
    {
        get
        {
            return canBeFlipped;
        }
    }
}
