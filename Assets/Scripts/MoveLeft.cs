using System.Collections;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10.0f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
    }
}
