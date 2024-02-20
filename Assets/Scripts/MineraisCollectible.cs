using UnityEngine;

public class MineraisCollectible: MonoBehaviour
{

    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);

            Inventory.instance.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
