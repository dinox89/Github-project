using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void SetCollisionEnabled(bool enabled)
    {
        GetComponent<BoxCollider2D>().enabled = enabled;
    }

}
