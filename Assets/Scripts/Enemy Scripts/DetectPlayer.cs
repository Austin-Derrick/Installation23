using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField]
    EnemyMovement enemyMovementScript;

    [SerializeField]
    GameObject objectBody;

    [SerializeField]
    Transform targetTransform;

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    bool hasFoundPlayer = false;
    bool facingLeft;
    

    //Start is called before the first frame update
    void Start()
    {
        hasFoundPlayer = false;
        bool facingLeft = true;
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

            if(gameObject.transform.position.x <= targetTransform.position.x && !facingLeft)
            {
                FlipSprite();
            }
            else if(gameObject.transform.position.x >= targetTransform.position.x && facingLeft)
            {
                FlipSprite();
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

    private void FlipSprite()
    {
        facingLeft = !facingLeft;
        objectBody.transform.Rotate(0, 180, 0);
    }
}
