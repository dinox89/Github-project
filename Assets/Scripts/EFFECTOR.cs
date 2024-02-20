using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFFECTOR : MonoBehaviour
{


    private PlatformEffector2D effector;

    private void Awake()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && effector.rotationalOffset != 0)
        {
            effector.rotationalOffset = 0;
        }
    }
}

