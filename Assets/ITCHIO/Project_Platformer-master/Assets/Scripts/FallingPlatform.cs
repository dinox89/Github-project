using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float maxFallDelay = 1f;

    private float fallDelay;
    Rigidbody2D rb2d;
    private bool isFalling = false;
	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        fallDelay = maxFallDelay;
	}
    private void Update()
    {
        if (isFalling)
        {
            fallDelay -= Time.deltaTime;
        }
        //Add shaking effect before fall action occurs

        if (fallDelay <= 0)
        {
            rb2d.isKinematic = false;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isFalling = true;
        }
    }
}
