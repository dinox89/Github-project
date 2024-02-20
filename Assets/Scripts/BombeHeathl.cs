using System.Collections;
using UnityEngine;

public class BombeHeathl : MonoBehaviour
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


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }


    public void TakeDamage(float _damage)
    {
        // Vérifier si l'ennemi a le tag "Tower" pour éviter de le tuer
        if (gameObject.CompareTag("Tower"))
        {
            // Appliquer des dégâts à l'ennemi mais ne pas le tuer car il a le tag "Tower"
            if (currentHealth > 0)
            {
                anim.SetTrigger("hurt");
                StartCoroutine(Invunerability());
            }
        }
        else
        {
            // L'ennemi n'a pas le tag "Tower", donc on applique les dégâts normalement et on le tue si sa santé atteint zéro
            if (invulnerable) return;
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

            if (currentHealth > 0)
            {
                anim.SetTrigger("hurt");
                StartCoroutine(Invunerability());
            }
            else
            {
                // Le reste du code pour tuer l'ennemi...
            }
        }
    }






    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respaw()
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
