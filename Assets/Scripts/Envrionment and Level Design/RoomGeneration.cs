using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject[] arenaRooms;

    [SerializeField]
    private GameObject[] hallwayRooms;

    [SerializeField]
    private GameObject[] verticalRooms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject[] ArenaRooms
    {
        get
        {
            return arenaRooms;
        }
    }
    public GameObject[] HallwayRooms
    {
        get
        {
            return hallwayRooms;
        }
    }
    public GameObject[] VerticalRooms
    {
        get
        {
            return verticalRooms;
        }
    }
}
