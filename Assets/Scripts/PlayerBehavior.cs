using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public bool isHoldingItem;
    PlayerInventory inventory;
    Vector3 mousePosition;
    Transform anchor;

    private void Start()
    {
        isHoldingItem = false;
        mousePosition = Vector3.zero;
        inventory = GetComponent<PlayerInventory>();
        anchor = transform.GetChild(2);
    }

    private void Update()
    {
        mousePosition = Input.mousePosition;
        if (isHoldingItem)
        {
            rotateItemInHands();
        }
    }

    private void rotateItemInHands()
    {
        // Vector math to get a vector that points in the direction that the tap is in
        Vector3 shootDirection = mousePosition - inventory.items[inventory.currentIndex].transform.position;
        // Get the tangent of the direction vector
        float thetaRadians = Mathf.Atan2(shootDirection.y, shootDirection.x);
        // convert the tangent of the direction vector into degrees. This is the angle that the touch is at relative to the player game object
        float thetaDegrees = thetaRadians * Mathf.Rad2Deg;
        // Rotates the play object according to the degrees that we calculated
        anchor.Rotate(new Vector3(0, 0, anchor.transform.position.z), thetaDegrees);
    }
}
