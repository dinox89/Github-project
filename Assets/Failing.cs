using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failing : MonoBehaviour
{
    [SerializeField] private  float fallDelay = 1f;

    private float destroyDelay;

    [SerializeField] private Rigidbody2D rb;




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine((IEnumerator)Fall());
        }
    }

    private IEnumerable Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
