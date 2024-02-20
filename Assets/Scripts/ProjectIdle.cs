using UnityEngine;

public class ProjectIdle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AudioClip hurt;
    private float direction;
    private bool hit;
    private float lifetime;


    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins")) // Vérifie si la collision est avec un mur
        {
            return; // Ignore la collision avec le mur
        }
        if (collision.CompareTag("Tower")) // Vérifie si la collision est avec un mur
        {
            SoundManager.instance.PlaySound(hurt);
        }
        if (collision.CompareTag("Pomme")) // Vérifie si la collision est avec un mur
        {
            return; // Ignore la collision avec le mur
        }

        if (collision.CompareTag("Ladder")) // Vérifie si la collision est avec un mur
        {
            anim.SetBool("L", true); // Ignore la collision avec le mur
        }

        if (collision.CompareTag("Cherry")) // Vérifie si la collision est avec un mur
        {
            return; // Ignore la collision avec le mur
        }
        if (collision.CompareTag("Fraise")) // Vérifie si la collision est avec un mur
        {
            return; // Ignore la collision avec le mur
        }
        if (collision.CompareTag("Wall") || collision.CompareTag("Ground"))  // Vérifie si la collision est avec un mur ou un terrain
        {
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
            return;
        }

         if(collision.CompareTag("BOX"))
        {
            
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
        }

        if (collision.CompareTag("Ennemy"))
        {
            collision.GetComponent<Heathl>().TakeDamage(1);
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
        }


        if (collision.CompareTag("Tower"))
        {
            collision.GetComponent<Heathl>().TakeDamage(1);
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
        }

        
        
        
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }



}
