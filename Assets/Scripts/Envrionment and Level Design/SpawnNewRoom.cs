using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnNewRoom : MonoBehaviour
{
    private GameObject roomToSpawn;
    private GameObject thisRoom;
    private RoomData newRoomData;
    private RoomData thisRoomData;

    private int flipChoice;

    private GameObject newConnector;

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
            int spawnLeftOrRight = 1;
            newRoomSpawned = true;
            roomToSpawn = ChooseRoomType();
            newRoomData = roomToSpawn.GetComponent<RoomData>();
            spawnOffset = new Vector3(newRoomData.RoomSize, 0, 0);          

            GameObject newRoom = Instantiate(roomToSpawn, this.transform.position + spawnOffset, new Quaternion(0, 0, 0, 0));

            newRoomData = newRoom.GetComponent<RoomData>();
            newConnector = newRoomData.entrances[Random.Range(0, newRoomData.entrances.Count)];
            ConnectorData thisConnectorData = this.GetComponent<ConnectorData>();
            ConnectorData newConnectorData = newConnector.GetComponent<ConnectorData>();

            if(thisConnectorData.IsRight && newConnectorData.IsRight == false) 
            {
                flipChoice = 1;
                spawnLeftOrRight = 1;
            }
            else if(thisConnectorData.IsRight == false && newConnectorData.IsRight)
            {
                flipChoice = 1;
                spawnLeftOrRight = -1;
            }
            else if(thisConnectorData.IsRight && newConnectorData.IsRight) 
            {
                flipChoice = -1;
                spawnLeftOrRight = 1;
                newRoomData.FlipSide();
            }
            else if(thisConnectorData.IsRight == false && newConnectorData.IsRight == false)
            {
                flipChoice = -1;
                spawnLeftOrRight = -1;
                newRoomData.FlipSide();
            }
            newRoom.gameObject.transform.localScale = new Vector3(flipChoice, 1, 1);
            SetPositionWithConnector(newRoom, spawnLeftOrRight);
            
            newConnector.SetActive(false);
            gameObject.SetActive(false);

            #region Old Code
            //if(newRoomData.CanBeFlipped)
            //{
            //    int[] flipChoices = new int[2] { -1, 1 };
            //    int numberInArray = flipChoices.Length;
            //    int randomChoice = flipChoices[Random.Range(0, numberInArray)];
            //    Debug.Log("Flip choice is " + randomChoice);
            //    newRoom.gameObject.transform.localScale = new Vector3(flipChoice, 1, 1);               
            //}

            //float lowestDifference = int.MaxValue;
            //thisRoomData.usedEntrance = gameObject;
            ////ADD TO ROOMDATA USEDENTRANCE ARRAY
            //for (int i = 0; i < newRoomData.entrances.Count; i++)
            //{
            //    float currentDifference = thisRoomData.usedEntrance.transform.position.x - newRoomData.entrances[i].transform.position.x;
            //    currentDifference = Mathf.Abs(currentDifference);
            //    if (currentDifference < lowestDifference)
            //    {
            //        lowestDifference = currentDifference;
            //        closestEntrance = newRoomData.entrances[i];
            //    }
            //}
            //SetPositionWithConnector(newRoom, flipChoice);
            //closestEntrance.gameObject.SetActive(false);
            #endregion

        }
    }

    private void LeftOrRight()
    {
        if (transform.position.x > transform.parent.position.x)
        {
            Debug.Log("Connector is to the RIGHT!");
            flipChoice = 1;   
        }
        else
        {
            Debug.Log("Connector is to the LEFT!");
            spawnOffset = -spawnOffset;
            flipChoice = -1;
        }
    }
    private void SetPositionWithConnector(GameObject room, int leftOrRight)
    {
        newConnector.transform.SetParent(null);
        room.transform.SetParent(newConnector.transform);
        newConnector.transform.position = gameObject.transform.position + new Vector3(2 * leftOrRight,0,0);
        room.transform.SetParent(null);
        newConnector.transform.SetParent(room.transform);
    }
    private GameObject ChooseRoomType()
    {
        GameObject roomToReturn = roomGenerationScript.ArenaRooms[0];
        int randomValue = Random.Range(1, 100);

        if (randomValue <= 60)
        {
            roomToReturn = roomGenerationScript.ArenaRooms[(Random.Range(0, roomGenerationScript.ArenaRooms.Length))];
        }
        else if (randomValue > 60 && randomValue <= 80)
        {
            roomToReturn = roomGenerationScript.HallwayRooms[(Random.Range(0, roomGenerationScript.HallwayRooms.Length))];
        }
        else if (randomValue > 80)
        {
            roomToReturn = roomGenerationScript.VerticalRooms[(Random.Range(0, roomGenerationScript.VerticalRooms.Length))];
        }
        return roomToReturn;
    }
}
