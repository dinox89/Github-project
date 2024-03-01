using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBLEVEL3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "DEB")
        {
            PlayerMovement.lastDEBLEVEL3 = transform.position;
        }
    }
}
