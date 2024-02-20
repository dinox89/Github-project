using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private AudioClip fireballSound;



    private Animator anim;
    private PlayerMovement playerMovement;

    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack() && Time.timeScale > 0)
        {
            anim.SetTrigger("attack"); // Déclenche immédiatement l'animation d'attaque
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    public void Attack()
    {
        if (playerMovement.IsGrounded()) // Ajout de cette condition pour vérifier si le personnage est au sol
        {
            
            SoundManager.instance.PlaySound(fireballSound);
            anim.SetTrigger("attack");
            cooldownTimer = 0;

            fireballs[FindFireball()].transform.position = firePoint.position;
            fireballs[FindFireball()].GetComponent<ProjectIdle>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack() && Time.timeScale > 0)
            Attack();

        if (Input.GetKey(KeyCode.Space))
            return; // Retourne sans exécuter la méthode Attack()

        cooldownTimer += Time.deltaTime;
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

  }


