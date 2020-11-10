using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehavior : MonoBehaviour
{
    public GameObject gun;
    public Transform gunBone;
    public Transform leftArmTargetTransform;
    public Transform rightHandAnchor;
    public Transform rightHandTargetTransform;

    Vector3 mousePos;

    private void Awake()
    {
        gun.transform.parent = leftArmTargetTransform;
        rightHandTargetTransform.parent = rightHandAnchor;

    }

    // Start is called before the first frame update
    void Start()
    {
        gunBone.position = leftArmTargetTransform.position;
        rightHandTargetTransform.position = rightHandAnchor.position;
    }

    // Update is called once per frame
    void Update()
    {
        //gun.transform.position = leftArmTargetTransform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotateItemInHands();
        //rightHandTargetTransform.position = rightHandAnchor.position;
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
