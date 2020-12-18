using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField]
    EnemyMovement enemyMovementScript;

    [SerializeField]
    Transform targetTransform;

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    bool hasFoundPlayer = false;

    //Start is called before the first frame update
    void Start()
    {
        hasFoundPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasFoundPlayer)
        {
            if (gameObject.transform.position.x >= targetTransform.position.x + 1.5f  || gameObject.transform.position.x <= targetTransform.position.x - 1.5f)
            {
                gameObject.transform.parent.position = Vector2.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Found player");
            targetTransform = collision.gameObject.transform;
            hasFoundPlayer = true;
        }
        Debug.Log("Something entered the trigger");
    }
}
