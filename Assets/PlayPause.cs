using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour
{
    [SerializeField] GameObject pause;




    public void Resume()
    {
        pause.SetActive(true);
    }
}
