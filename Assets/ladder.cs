using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{

    private Animator anim;
    [SerializeField] private AudioClip Sound;


    private bool sonJoue = false;
    public GameObject Barelle;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireball") && !sonJoue)
        {
            anim.SetBool("L", true);
            SoundManager.instance.PlaySound(Sound);
            sonJoue = true;

        }

    }

    public void EnableDoorCollision()
    {
        BoxCollider2D doorCollider = Barelle.GetComponent<BoxCollider2D>();
        doorCollider.enabled = true;
    }

    private void DisableDoorCollision()
    {
        BoxCollider2D doorCollider = Barelle.GetComponent<BoxCollider2D>();
        doorCollider.enabled = false;
    }
}
