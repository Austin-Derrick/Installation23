using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    [SerializeField]
    private float roomSize;

    [SerializeField]
    public List<GameObject> entrances = new List<GameObject>();

    public GameObject usedEntrance;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
