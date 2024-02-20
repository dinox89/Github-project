using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieFireballHolder : MonoBehaviour
{

    [SerializeField] private Transform ennemy;

    private void Update()
    {
        transform.localScale = ennemy.localScale;
    }

}
