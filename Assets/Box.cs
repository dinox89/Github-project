using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;

    public Animator anim;

    public SpriteRenderer spriteRenderer;

    public GameObject brokenParts;

    public float jumpForce = 4f;

    public int lifes = 1;

    public GameObject boxcollider;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Fireball"))
        {
            LosseLife();
        }
    }

    public void LosseLife()
    {
        lifes--;
        anim.Play("Hit");

        CheckLife();
    }

    public void CheckLife()
    {
        if (lifes <= 0) 
        {
            boxcollider.SetActive(false);
            brokenParts.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("DestroyBox", 0.5f);
            SoundManager.instance.PlaySound(pickupSound);
        }
    }

    public void DestroyBox()
    {
        Destroy(gameObject);
    }
}
