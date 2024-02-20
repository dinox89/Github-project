
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if(collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            collision.GetComponent<Heathl>().AddHealth(healthValue);
            Inventory.instance.Addfruit(1);
            Destroy(gameObject);
        }
    }
}
