using UnityEngine;


public class CoinsCollecter : MonoBehaviour

{

    [SerializeField] private AudioClip pickupSound;
    private CoinManager coinmanager;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
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