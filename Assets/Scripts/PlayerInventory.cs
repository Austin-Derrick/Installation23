using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    public int maxItems = 5;

    [SerializeField]
    public GameObject[] items;

    public bool isFull { get; private set; }
    // Most recently added Item
    public int mostRecentItem = 0;
    public int currentIndex = 0;
    public int nextOpenSpace = 0;

    private void Awake()
    {
        items = new GameObject[maxItems];
        isFull = false;
    }

    public void addItem(GameObject itemToAdd)
    {
        if (nextOpenSpace == maxItems - 1)
        {
            Debug.Log("Not Enough room in inventory");
        }
        else
        {
            Debug.Log($"Added {itemToAdd.name} in inventory");
            items[nextOpenSpace] = itemToAdd;
            mostRecentItem = nextOpenSpace;
            nextOpenSpace++;
        }
    }

    public void removeItem(int indexToRemove)
    {
        items[indexToRemove] = null;
        if (indexToRemove == currentIndex)
        {
            currentIndex = currentIndex == 0 ? 0 : currentIndex--;
        }
    }

    public void swapItem(int indexToSwap, GameObject itemToAdd)
    {
        Debug.Log($"Removing {items[indexToSwap].gameObject.name}");
        items[indexToSwap] = itemToAdd;
    }
}