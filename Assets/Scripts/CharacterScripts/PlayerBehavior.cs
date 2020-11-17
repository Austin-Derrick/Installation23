using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class PlayerBehavior : MonoBehaviour
{
    public bool isHoldingItem;
    PlayerInventory inventory;
    Vector3 mousePos;
    [SerializeField] 
    Transform anchor;
    GameObject currentWeapon;
    bool isFacingRight = true;
    int currentInventoryIndex = 0;

    private void Start()
    {
        isHoldingItem = false;
        mousePos = Vector3.zero;
        inventory = GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (isHoldingItem)
        {
            if (currentWeapon == null)
            {
                currentWeapon = inventory.items[currentInventoryIndex];
            }
            else
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rotateItemInHands();
            }
        }
    }

    private void rotateItemInHands()
    {
        //if (mousePos.x < transform.position.x && isFacingRight)
        //{
        //    currentWeapon.GetComponent<SpriteRenderer>().flipY = true;
        //    isFacingRight = false;
        //}
        //if (mousePos.x > transform.position.x && !isFacingRight)
        //{
        //    currentWeapon.GetComponent<SpriteRenderer>().flipY = false;
        //    isFacingRight = true;
        //}
        //// Vector math to get a vector that points in the direction that the tap is in
        //Vector2 shootDirection = (mousePos - anchor.position);
        //// Get the tangent of the direction vector and convert the angle to degrees
        //float thetaDegrees = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        //// Rotates the play object according to the degrees that we calculated
        //anchor.transform.eulerAngles = new Vector3(0, 0, thetaDegrees);
    }
}