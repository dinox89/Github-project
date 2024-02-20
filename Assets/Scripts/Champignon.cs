using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champignon : MonoBehaviour
{



    public Animator anim;
    [SerializeField] private AudioClip sound;
    public float Jumpforce;





    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {

            anim.SetBool("Jump", false);
            coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Jumpforce), ForceMode2D.Impulse);

            SoundManager.instance.PlaySound(sound);
        }
    }

} 
