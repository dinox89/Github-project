using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingV : MonoBehaviour
{

    [SerializeField] float offsetLeft = 0, offsetRight = 0, speed = 1;
    [SerializeField] bool hasReachedRight = false, hasReachedLeft = false;
    Vector3 startPosition = Vector3.zero;

    void Awake()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hasReachedRight)
        {
            if (transform.position.x < startPosition.x + offsetRight)
            {
                // Move platform to the right        
            }
            else if (transform.position.x >= startPosition.x + offsetRight)
            {
                hasReachedRight = true;
                hasReachedLeft = false;
            }
        }
        else if (!hasReachedLeft)
        {
            if (transform.position.x > startPosition.x + offsetLeft)
            {
                // Move platform to the left 
            }
            else if (transform.position.x <= startPosition.x + offsetLeft)
            {
                hasReachedRight = false;
                hasReachedLeft = true;
            }
        }
    }
    void Move(float offset)
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 new Vector3(startPosition.x + offset,
                                                             transform.position.y,
                                                             transform.position.z),
                                                 speed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;

        float width = GetComponent<SpriteRenderer>().size.x;
        float height = GetComponent<SpriteRenderer>().size.y;

        float offsetNegX = startPosition.x - (width / 2) + offsetLeft;
        float offsetPosX = startPosition.x + (width / 2) + offsetRight;
        float offsetBottomPoint = startPosition.y + (height / 2);
        float offsetTopPoint = startPosition.y - (height / 2);
        float offsetTransformNegX = transform.position.x - (width / 2) + offsetLeft;
        float offsetTransformPosX = transform.position.x + (width / 2) + offsetRight;
        float offsetTransformTopPoint = transform.position.y + (height / 2);
        float offsetTransformBottomPoint = transform.position.y - (height / 2);

        Gizmos.DrawLine(new Vector3(offsetNegX, offsetTopPoint, 0),
                        new Vector3(offsetNegX, offsetBottomPoint, 0));

        Gizmos.color = Color.green;

        Gizmos.DrawLine(new Vector3(offsetPosX, offsetTopPoint, 0),
                        new Vector3(offsetPosX, offsetBottomPoint, 0));

        Gizmos.color = Color.blue;

        Gizmos.DrawLine(new Vector3(offsetTransformNegX, offsetTransformBottomPoint, 0),
                        new Vector3(offsetTransformNegX, offsetTransformTopPoint, 0));
        Gizmos.DrawLine(new Vector3(offsetTransformPosX, offsetTransformBottomPoint, 0),
                        new Vector3(offsetTransformPosX, offsetTransformTopPoint, 0));
    }
}
