using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fr : MonoBehaviour
{

    [SerializeField] private AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(sound);
        }
    }
}
