using Unity.Burst.CompilerServices;
using UnityEngine;

public class CourbedProjectile : EnnemyDamage
{
    public GameObject tower;
    public GameObject target;

    public float speed;

    private float towerX;
    private float targetX;

    private float dist;
    private float nextX;
    private float baseY;
    private float height;

    private Animator anim;
    private BoxCollider2D box;
    private bool cibleEnVue = false;

    public void Start()
    {
        tower = GameObject.FindGameObjectWithTag("Tower");
        target = GameObject.FindGameObjectWithTag("Player");



    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }



    private void Update()
    {
        if (!cibleEnVue)
            return;
        towerX = tower.transform.position.x;
        targetX = target.transform.position.x;
        dist = targetX - towerX;

        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(tower.transform.position.y, target.transform.position.y, (nextX - towerX) / dist);
        height = 2 * (nextX - towerX) * (nextX - targetX) / (-0.25f * dist * dist);

        Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;

        if  (transform.position.x <= target.transform.position.x)

        {
            box.enabled = true;
            anim.SetTrigger("explode");

        }
    }


    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }

    public void ActiverProjectile(bool enVue)
    {
        cibleEnVue = enVue;

        // Ajouter toute autre logique liée à l'activation du projectile
    }

}