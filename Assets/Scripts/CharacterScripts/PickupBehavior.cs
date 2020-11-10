using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    [SerializeField]
    PlayerInventory inventory;

    [SerializeField]
    PlayerBehavior playerBehavior;

    public Transform anchor;

    int inventoryIndex = 0;

    private void Start()
    {
        inventory = GetComponent<PlayerInventory>();
        inventoryIndex = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            if (inventory.currentIndex <= inventory.maxItems - 1)
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<ItemComponents>().collider, GetComponent<Collider2D>(), true);
                inventory.addItem(collision.gameObject);

                inventory.items[inventoryIndex].transform.position = anchor.position;
                inventory.items[inventoryIndex].transform.rotation = anchor.rotation;
                inventory.items[inventoryIndex].transform.parent = anchor.transform;

                playerBehavior.isHoldingItem = true;

                inventoryIndex++;
                inventory.nextOpenSpace = inventoryIndex;
            }
            else
            {
                Debug.Log("Inventory is full");
            }
        }
    }
}

