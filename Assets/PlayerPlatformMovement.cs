using UnityEngine;

public class PlayerPlatformMovement : MonoBehaviour
{
    private bool isOnPlatform = false;
    private Vector3 platformLastPosition;

    private void Update()
    {
        if (isOnPlatform)
        {
            Vector3 platformDeltaPosition = transform.parent.position - platformLastPosition;
            transform.position += platformDeltaPosition;
            platformLastPosition = transform.parent.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MovingPlatform")
        {
            isOnPlatform = true;
            platformLastPosition = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MovingPlatform")
        {
            isOnPlatform = false;
        }
    }

    
}
