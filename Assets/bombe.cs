using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombe : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioClip sound;


    private void Awake()
    {
        anim = GetComponent<Animator>();

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fireball")
        {
            anim.SetTrigger("Z");
            SoundManager.instance.PlaySound(sound);
        }
    }
}
