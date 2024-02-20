using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxe : MonoBehaviour
{
    private Animator anim;
    public GameObject coinPrefab; // Référence au prefab de la pièce
    public int numberOfCoins = 10;

    [SerializeField] private AudioClip sound;
    private bool sonJoue = false; // Variable pour contrôler l'état du son

    public float jumpForce = 5.0f; // Force pour faire sauter les pièces

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fireball")
        {
            anim.SetBool("BOX", true);
            SoundManager.instance.PlaySound(sound);
            sonJoue = true;

            for (int i = 0; i < numberOfCoins; i++)
            {
                // Générer une pièce à une position aléatoire à proximité du coffre
                Vector2 coinPosition = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 0f, 0f);

                // Instancier la pièce et lui appliquer une force verticale
                GameObject coinInstance = Instantiate(coinPrefab, coinPosition, Quaternion.identity);
                coinsChestCollecter coinsChestCollecter = coinInstance.GetComponent<coinsChestCollecter>();
                coinsChestCollecter.ApplyVerticalForce(jumpForce); // Utilisez la variable jumpForce au lieu d'une valeur fixe comme 5.0f



            }

            GetComponent<Collider2D>().enabled = false;
        }
    }
}

