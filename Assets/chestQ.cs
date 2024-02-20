using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestQ : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioClip sound;
    private bool sonJoue = false; // Variable pour contrôler l'état du son


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !sonJoue)
        {
            anim.SetBool("OPEN", true);
            SoundManager.instance.PlaySound(sound);
            sonJoue = true;
        }
    }

  
}
