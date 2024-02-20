
using UnityEngine;

public class PommeCollecter : MonoBehaviour
{

    [SerializeField] private AudioClip pickupSound;


    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);

            Inventory.instance.Addfruit(1);
            Destroy(gameObject);
        }
    }
}
