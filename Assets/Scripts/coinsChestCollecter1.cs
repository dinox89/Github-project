using UnityEngine;

public class coinsChestCollecter : MonoBehaviour

{

    [SerializeField] private AudioClip pickupSound;
    private CoinManager coinmanager;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(pickupSound);
            Inventory.instance.AddCoins(1);
            Destroy(gameObject);
        }
    }
    public void ApplyVerticalForce(float force)
    {
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
}