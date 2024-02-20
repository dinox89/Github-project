using Unity.Burst.CompilerServices;
using UnityEngine;

public class FlyKikc : MonoBehaviour
{
    public bool hit;

    private Animator animator; // Référence à l'Animator

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformFlyKick()
    {
        // Déclencher l'animation d'attaque
        animator.SetTrigger("FlyKIkc");
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.CompareTag("Ennemy"))
        {
            Heathl enemyHealth = collision.GetComponent<Heathl>();
            if (enemyHealth != null)
            {
                Debug.Log("Dealing damage to enemy: " + collision.gameObject.name);
                enemyHealth.TakeDamage(1);
                hit = true;
            }
            else
            {
                Debug.LogWarning("Enemy does not have Health script attached: " + collision.gameObject.name);
            }
        }
        else
        {
            Debug.LogWarning("Collision is not with an enemy: " + collision.gameObject.name);
        }
    }


}






