using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestHEARTH : MonoBehaviour
{
    private Animator anim;

    public GameObject HearthPrefab;

    public int numberofHearth;
    [SerializeField] private AudioClip sound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("OPEN", true);
            SoundManager.instance.PlaySound(sound);
            for (int i = 0; i < numberofHearth; i++)
            {
                // Générer une pièce à une position aléatoire à proximité du coffre

                Vector2 hearthPosition = transform.position + new Vector3(Random.Range(1f, 1f), Random.Range(1f, 1f), 1f);
                Instantiate(HearthPrefab, hearthPosition, Quaternion.identity);
            }

            GetComponent<Collider2D>().enabled = false;
        }
    }

}
