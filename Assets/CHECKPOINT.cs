    using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CHECKPOINT : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.transform.tag == "Player" )
        {
            PlayerMovement.lastCheckpointposition = transform.position;
         }
}

}
