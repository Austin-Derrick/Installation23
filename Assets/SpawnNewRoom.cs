using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnNewRoom : MonoBehaviour
{
    private GameObject roomToSpawn;
    private GameObject thisRoom;
    private RoomData newRoomData;
    private RoomData thisRoomData;

    private GameObject closestEntrance;

    public BoxCollider2D nextRoomCollider;

    private Vector3 spawnOffset;

    private Vector3 newRoomSpawnPos;
    public bool newRoomSpawned = false;

    private GameObject RoomGenerationObject;
    private RoomGeneration roomGenerationScript;

    // Start is called before the first frame update
    void Start()
    {
        
        nextRoomCollider = GetComponent<BoxCollider2D>();
        thisRoom = gameObject.transform.parent.gameObject;
        thisRoomData = GetComponentInParent<RoomData>();

        roomGenerationScript = GameObject.Find("Room Generation").GetComponent<RoomGeneration>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && newRoomSpawned != true)
        {
            newRoomSpawned = true;  
            roomToSpawn = roomGenerationScript.ArenaRooms[(Random.Range(0,2))];
            newRoomData = roomToSpawn.GetComponent<RoomData>();
            spawnOffset = new Vector3(newRoomData.RoomSize, 0, 0);
            LeftOrRight();
            newRoomSpawnPos = thisRoom.transform.position + spawnOffset;

            GameObject newRoom = Instantiate(roomToSpawn, newRoomSpawnPos, new Quaternion(0, 0, 0, 0));
            newRoomData = newRoom.GetComponent<RoomData>();

            
            float lowestDifference = int.MaxValue;
            thisRoomData.usedEntrance = gameObject;
            //ADD TO ROOMDATA USEDENTRANCE ARRAY
            for (int i = 0; i < newRoomData.entrances.Count; i++)
            {
                float currentDifference = thisRoomData.usedEntrance.transform.position.x - newRoomData.entrances[i].transform.position.x;
                currentDifference = Mathf.Abs(currentDifference);
                if (currentDifference < lowestDifference)
                {
                    lowestDifference = currentDifference;
                    closestEntrance = newRoomData.entrances[i];
                }

            }
            closestEntrance.gameObject.SetActive(false);
            Debug.Log("Closest entrance detected" + closestEntrance.name);

            gameObject.SetActive(false);
        }
    }

    private void LeftOrRight()
    {
        if (transform.position.x > transform.parent.position.x)
        {
            Debug.Log("Connector is to the RIGHT!");
        }
        else
        {
            Debug.Log("Connector is to the LEFT!");
            spawnOffset = -spawnOffset;
        }
    }
}
