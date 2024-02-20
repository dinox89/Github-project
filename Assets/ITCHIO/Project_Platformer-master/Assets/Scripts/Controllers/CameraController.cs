using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 velocity;

    public GameObject player;

    public float smoothTimeY;
    public float smoothTimeX;

    public Vector2 cameraOffset;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);


        transform.position = new Vector3(posX + cameraOffset.x, posY + cameraOffset.y, transform.position.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x), Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y),transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CameraTrigger"))
        {
            cameraOffset.y = 0;
        }   
    }
}
