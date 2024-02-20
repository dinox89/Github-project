using UnityEngine;

public class DEATHENNEMY : MonoBehaviour
{
    public GameObject heartPrefab; // Préfabriqué de la pièce de cœur
    public int health = 1; // Points de vie de l'ennemi

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Fait apparaître une pièce de cœur à la position de l'ennemi
        GameObject heart = Instantiate(heartPrefab, transform.position, Quaternion.identity);
        heart.SetActive(true);

        // Désactive l'ennemi
        gameObject.SetActive(false);
    }
}
