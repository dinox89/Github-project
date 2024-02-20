using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolinne : MonoBehaviour
{
    private Animator anim;
    public float h = 20f;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("Player"))
        {
            anim.SetBool("TRAMP", true);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * h, ForceMode2D.Impulse);
        }
    }
}
