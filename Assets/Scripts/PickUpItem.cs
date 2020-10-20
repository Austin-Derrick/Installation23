using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    PlayerInventory inventory;

    Transform anchor;

    [SerializeField]
    PlayerBehavior playerBehavior;

    private void Start()
    {
        anchor = transform.GetChild(2);
        inventory = GetComponent<PlayerInventory>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            if (inventory.currentIndex <= inventory.maxItems - 1)
            {
                inventory.addItem(collision.gameObject);
                if (inventory.currentIndex == 0)
                {
                    //Physics2D.IgnoreCollision(inventory.items[0].GetComponent<ItemComponents>().collider, GetComponent<Collider2D>(), true);

                    Debug.Log("Setting parent");
                    collision.transform.position = anchor.position;
                    playerBehavior.isHoldingItem = true;
                    collision.gameObject.transform.SetParent(anchor, true);
                }
            }
        }
    }
}



