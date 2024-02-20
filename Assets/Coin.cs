using UnityEngine;


public class Coin: MonoBehaviour

{

    [SerializeField] private AudioClip pickupSound;
    private CoinManager coinmanager;


    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Player")
        {


            SoundManager.instance.PlaySound(pickupSound);

            Inventory.instance.AddCoins(100);

            Destroy(gameObject);

        }
    }
}
