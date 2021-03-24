using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnNewRoom : MonoBehaviour
{
    private GameObject connectedRoom;
    private GameObject thisRoom;
    private ConnectorData thisConnectorData;
    private ConnectorData linkedConnectorData;
    private RoomData connectedRoomData;
    private RoomData thisRoomData;

    private int flipChoice;

    private GameObject newConnector;

    //private Vector3 spawnOffset;

    //private Vector3 newRoomSpawnPos;
    //public bool roomFits = false;

    private GameObject RoomGenerationObject;
    private RoomGeneration roomGenerationScript;

    // Start is called before the first frame update
    void Start()
    {
        thisRoom = gameObject.transform.parent.gameObject;
        thisRoomData = GetComponentInParent<RoomData>();

        roomGenerationScript = GameObject.Find("Room Generation").GetComponent<RoomGeneration>();
        thisConnectorData = this.GetComponent<ConnectorData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && thisConnectorData.roomSpawned != true)
        {
            thisConnectorData.roomSpawned = true;
            connectedRoom = Instantiate(ChooseRoomType(), this.transform.parent.position, new Quaternion(0, 0, 0, 0));
            connectedRoomData = connectedRoom.GetComponent<RoomData>();
            connectedRoom.SetActive(false);

            newConnector = connectedRoomData.entrances[Random.Range(0, connectedRoomData.entrances.Count)];
            
            linkedConnectorData = newConnector.GetComponent<ConnectorData>();
            linkedConnectorData.roomSpawned = true;
            connectedRoom.gameObject.transform.localScale = new Vector3(LinkConnectors(thisConnectorData,linkedConnectorData), 1, 1);

            linkedConnectorData.connectedRoom = thisRoom;
            linkedConnectorData.linkedConnector = this.gameObject;
            thisConnectorData.connectedRoom = connectedRoom;
            thisConnectorData.linkedConnector = newConnector;

            MoveBetweenRooms(newConnector, linkedConnectorData, collision.gameObject);
            thisRoom.SetActive(false);
            connectedRoom.SetActive(true);

            #region Old Code
            //int spawnLeftOrRight = 1;
            //newRoomSpawned = true;
            //connectedRoom = ChooseRoomType();
            //connectedRoomData = connectedRoom.GetComponent<RoomData>();
            ////spawnOffset = new Vector3(newRoomData.RoomSize, 0, 0);          

            //GameObject newRoom = Instantiate(connectedRoom,this.transform.parent.position, new Quaternion(0, 0, 0, 0));
            ////GameObject newRoom = Instantiate(connectedRoom, this.transform.position + spawnOffset, new Quaternion(0, 0, 0, 0));

            //connectedRoomData = newRoom.GetComponent<RoomData>();
            //newConnector = connectedRoomData.entrances[Random.Range(0, connectedRoomData.entrances.Count)];
            //ConnectorData thisConnectorData = this.GetComponent<ConnectorData>();
            //ConnectorData newConnectorData = newConnector.GetComponent<ConnectorData>();

            //if(thisConnectorData.IsRight && newConnectorData.IsRight == false) 
            //{
            //    flipChoice = 1;
            //    spawnLeftOrRight = 1;
            //}
            //else if(thisConnectorData.IsRight == false && newConnectorData.IsRight)
            //{
            //    flipChoice = 1;
            //    spawnLeftOrRight = -1;
            //}
            //else if(thisConnectorData.IsRight && newConnectorData.IsRight) 
            //{
            //    flipChoice = -1;
            //    spawnLeftOrRight = 1;
            //    connectedRoomData.FlipSide();
            //}
            //else if(thisConnectorData.IsRight == false && newConnectorData.IsRight == false)
            //{
            //    flipChoice = -1;
            //    spawnLeftOrRight = -1;
            //    connectedRoomData.FlipSide();
            //}
            //newRoom.gameObject.transform.localScale = new Vector3(flipChoice, 1, 1);
            //SetPositionWithConnector(newRoom, spawnLeftOrRight);

            //newConnector.SetActive(false);
            //gameObject.SetActive(false);
            #endregion
            #region Older Code
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
        else if(collision.gameObject.CompareTag("Player") && thisConnectorData.roomSpawned == true)
        {
            thisRoom.SetActive(false);
            MoveBetweenRooms(thisConnectorData.linkedConnector, thisConnectorData.linkedConnector.GetComponent<ConnectorData>(), collision.gameObject);            
            thisConnectorData.connectedRoom.SetActive(true);
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
            //spawnOffset = -spawnOffset;
            flipChoice = -1;
        }
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
    private void MoveBetweenRooms(GameObject newConnector, ConnectorData newConnectorData, GameObject playerCharacter)
    {
        int spawnOffset = 0;
        
        if(newConnectorData.isRight)
        {
            spawnOffset = -1;
        }
        else
        {
            spawnOffset = 1;
        }
        Vector3 newSpawnPosition = new Vector3(newConnector.transform.position.x + spawnOffset, newConnector.transform.position.y, 0);
        playerCharacter.transform.position = newSpawnPosition;
    }
    private int LinkConnectors(ConnectorData thisConnector, ConnectorData newRoomConnector)
    {
        int flipChoice = 1;
        if (thisConnector.IsRight && newRoomConnector.IsRight == false)
        {
            flipChoice = 1;
        }
        else if (thisConnector.IsRight == false && newRoomConnector.IsRight)
        {
            flipChoice = 1;
        }
        else if (thisConnector.IsRight && newRoomConnector.IsRight)
        {
            flipChoice = -1;
            connectedRoomData.FlipSide();
        }
        else if (thisConnector.IsRight == false && newRoomConnector.IsRight == false)
        {
            flipChoice = -1;
            connectedRoomData.FlipSide();
        }
        return flipChoice;
    }
}
