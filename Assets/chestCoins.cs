using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestCoins : MonoBehaviour
{
    private Animator anim;
    public GameObject coinPrefab;
    public int numberOfCoins = 10;

    [SerializeField] private AudioClip sound;
    private bool sonJoue = false; // Variable pour contrôler l'état du son


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
            sonJoue = true;

            for (int i = 0; i < numberOfCoins; i++)
            {
                // Générer une pièce à une position aléatoire à proximité du coffre
                Vector2 coinPosition = transform.position + new Vector3(Random.Range(1f, 1f), Random.Range(0f, 1f), 0f);
                Instantiate(coinPrefab, coinPosition, Quaternion.identity);

            }

            GetComponent<Collider2D>().enabled = false;
        }
    }

}
