using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class flip : MonoBehaviour
{
    public GameObject player;
    public bool Flip;



    private void Update()
    {
        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            scale.x  = - Mathf.Abs(scale.x) * (Flip ? -1 : 1);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (Flip ? -1 : -1);
        }

    }

}
