using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] private AudioClip Sound;



    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Heathl>().TakeDamage(damage);
         SoundManager.instance.PlaySound(Sound);



    }
}
