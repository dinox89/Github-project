using UnityEngine;

public class Rangedpatrolling : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    [Header("Player Detection")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float detectionDistance;
    private Heathl playerHealth;
    [SerializeField] private int damage;




    private void Awake()
    {
        initScale = enemy.localScale;

    }
    private void Update()
    {



        if (PlayerDetected())
        {
            StopPatrol();
            anim.SetTrigger("rangedAttack");
        }
        else if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
        // check if enemy is currently patrolling
        if (enabled)
        {
            anim.SetBool("moving", false);
            idleTimer += Time.deltaTime;

            if (idleTimer > idleDuration)
                movingLeft = !movingLeft;
        }
    }


    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);



        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }

    private bool PlayerDetected()
    {
        RaycastHit2D hit =
            Physics2D.Raycast(enemy.position, Vector2.right * enemy.localScale.x, detectionDistance, playerLayer);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    private void StopPatrol()
    {
        anim.SetBool("moving", false);

    }
}
