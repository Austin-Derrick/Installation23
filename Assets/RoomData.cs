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

    private CompositeCollider2D compCollider;

    public GameObject usedEntrance;
    

    // Start is called before the first frame update
    void Start()
    {
        compCollider = GetComponentInChildren<CompositeCollider2D>();
        Debug.Log(compCollider.bounds);
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
    public bool CanBeFlipped
    {
        get
        {
            return canBeFlipped;
        }
    }
}
