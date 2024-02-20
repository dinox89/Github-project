using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Animator doorAnimator;
    public GameObject door;
    [SerializeField] private AudioClip Sound;


    private bool sonJoue = false; 



    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == ("Player") && !sonJoue)
        {
            anim.SetBool("OnPivot", true);
            SoundManager.instance.PlaySound(Sound);
            doorAnimator.SetBool("Dooropen", true);
            sonJoue = true;

        }
    }

    public void EnableDoorCollision()
    {
        BoxCollider2D doorCollider = door.GetComponent<BoxCollider2D>();
        doorCollider.enabled = true;
    }

    private void DisableDoorCollision()
    {
        BoxCollider2D doorCollider = door.GetComponent<BoxCollider2D>();
        doorCollider.enabled = false;
    }
}
