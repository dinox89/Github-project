using System.Collections;
using UnityEngine;

public class Heathl : MonoBehaviour
{
    [Header("Heathl")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private bool invulnerable;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashed;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;

    public GameManager gameManager;
    private bool isDead;

    
    public GameObject coinPrefab; 
    public int numberOfCoins = 10;
    public float jumpForce = 5.0f; // Force pour faire sauter les pièces





    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }

    public void ReviveAfterAds()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
        StartCoroutine(Invunerability());

        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
    }
    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead && !isDead)
            {
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }

                anim.SetBool("grouned", true);

                anim.SetTrigger("die");

                Vector2 coinPosition = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 0f, 0f);

                // Instancier la pièce et lui appliquer une force verticale
                GameObject coinInstance = Instantiate(coinPrefab, coinPosition, Quaternion.identity);
                coinsChestCollecter coinsChestCollecter = coinInstance.GetComponent<coinsChestCollecter>();
                coinsChestCollecter.ApplyVerticalForce(jumpForce); // Utilisez la variable jumpForce au lieu d'une valeur fixe comme 5.0f

                if (gameManager != null)
                {
                    gameManager.gameOver();
                    
                }


                isDead = true;
                gameObject.SetActive(false);

                dead = true;

                SoundManager.instance.PlaySound(deathSound);
            }
        }
    }





    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respaw()
    {

        if (!gameObject.activeSelf)
        {
            // Le joueur est inactif, ne démarrez pas la coroutine
            return;
        }
        dead = false;
        AddHealth(startingHealth);


      
        anim.ResetTrigger("die");
        anim.Play("Idle");
        StartCoroutine(Invunerability());

        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);

        for (int i = 0; i < numberOfFlashed; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashed * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashed * 2));
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    private void Desactivate()
    {
        gameObject.SetActive(false);
    }

    public void ReviveWithFullHearts()
    {
        currentHealth = startingHealth;
        Respaw();
    }

   



}

