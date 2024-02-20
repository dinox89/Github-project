using System.Collections.Generic;
using UnityEngine;

public class Bombeennemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;



    [Header("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private float maxDistance;
    public GameObject player;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderRadius;
    [SerializeField] private float colliderOffsetX; // Offset horizontal du cercle de détection
    [SerializeField] private LayerMask obstacleLayer;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Fireball Sound")]
    [SerializeField] private AudioClip fireballSound;

    //References
    private Animator anim;
    private EnemyPatrol enemyPatrol;
    private bool joueurEnVue = false;

    private List<GameObject> bombPool;
    public GameObject bombPrefab;



    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        bombPool = new List<GameObject>();

    }

    private void Update()
    {
        Vector3 scale = transform.localScale;

       



        transform.localScale = scale;
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            joueurEnVue = true;

            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("rangedAttack");
            }
        }
        else
        {
            joueurEnVue = false;
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private void RangedAttack()
    {
        
        cooldownTimer = 0;

        // Trouver une bombe disponible dans le pool
        GameObject bomb = null;
        foreach (GameObject b in bombPool)
        {
            if (!b.activeInHierarchy)
            {
                bomb = b;
                break;
            }
        }

        // Si toutes les bombes du pool sont utilisées, créez une nouvelle bombe
        if (bomb == null)
        {
            bomb = Instantiate(bombPrefab);
            bombPool.Add(bomb);
        }

        // Activer la bombe et la positionner sur le firepoint
        bomb.transform.position = firepoint.position;
        bomb.SetActive(true);
        bomb.GetComponent<CourbedProjectile>().ActiverProjectile(joueurEnVue);
    }




    private bool PlayerInSight()
    {
        // Placer le cercle de détection à l'offset horizontal spécifié par colliderOffsetX
        Vector2 circleCenter = transform.position + new Vector3(colliderOffsetX, 0f, 0f);
        Collider2D[] hits = Physics2D.OverlapCircleAll(circleCenter, colliderRadius, playerLayer);
        foreach (Collider2D hit in hits)
        {
            if (!Physics2D.Linecast(circleCenter, hit.transform.position, obstacleLayer))
            {
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        // Dessiner le cercle de détection à l'offset horizontal spécifié par colliderOffsetX
        Vector2 circleCenter = transform.position + new Vector3(colliderOffsetX, 0f, 0f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(circleCenter, colliderRadius);
    }
}