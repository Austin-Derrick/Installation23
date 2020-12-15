using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehavior : MonoBehaviour
{
    public Transform gunAnchor;
    public GameObject gun;
    public Transform gunBone;
    public Transform leftArmTargetTransform;
    public Transform rightHandAnchor;
    public Transform rightHandTargetTransform;
    public bool isHoldingItem = false;
    Vector3 mousePos;
    public Animator animator;

    public int counter = 0;
    //private void Awake()
    //{
    //    gun.transform.parent = leftArmTargetTransform;
    //    rightHandTargetTransform.parent = rightHandAnchor;
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    gunBone.position = leftArmTargetTransform.position;
    //    rightHandTargetTransform.position = rightHandAnchor.position;
    //}

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsHoldingGun", isHoldingItem);
        if (counter == 1)
        {
            gun.transform.position = gunAnchor.position;
            gun.transform.parent = gunAnchor;
            rightHandTargetTransform.position = rightHandAnchor.position;
            rightHandTargetTransform.parent = rightHandAnchor;
            //gunBone.position = leftArmTargetTransform.position;
        }
        if (isHoldingItem && counter > 0)
        {
            //gun.transform.position = leftArmTargetTransform.position;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rotateItemInHands();
            rightHandTargetTransform.position = rightHandAnchor.position;
            counter++;
        }
    }

    private void rotateItemInHands()
    {
        // Vector math to get a vector that points in the direction that the tap is in
        Vector2 shootDirection = (mousePos - gunBone.position);
        // Get the tangent of the direction vector and convert the angle to degrees
        float thetaDegrees = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        // Rotates the play object according to the degrees that we calculated
        gunBone.transform.eulerAngles = new Vector3(0, 0, thetaDegrees);
    }
}
