﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public bool isHoldingItem;
    PlayerInventory inventory;
    Vector3 mousePos;
    [SerializeField] Transform anchor;

    private void Start()
    {
        isHoldingItem = false;
        mousePos = Vector3.zero;
        inventory = GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isHoldingItem)
        {
            rotateItemInHands();
            setGunPosition();
        }
    }

    private void setGunPosition()
    {
        inventory.items[0].transform.position = anchor.position;
        inventory.items[0].transform.rotation = anchor.rotation;
    }

    private void rotateItemInHands()
    {
        // Vector math to get a vector that points in the direction that the tap is in
        Vector3 shootDirection = (mousePos - anchor.position);
        // Get the tangent of the direction vector and convert the angle to degrees
        float thetaDegrees = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        // Rotates the play object according to the degrees that we calculated
        anchor.transform.eulerAngles = new Vector3(0, anchor.transform.rotation.y, thetaDegrees);
    }
}
