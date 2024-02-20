using UnityEngine;

public class SpikeHeadV : EnnemyDamage
{
    [Header("SpikeHead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;

    private Vector3 direction;
    private Vector3 destination;
    private float checkTimer;
    private bool attacking;

    private void OnEnable()
    {
        Stop();
    }

    private void Update()
    {
        // Move spikehead to destination only if attacking
        if (attacking)
        {
            transform.Translate(destination * Time.deltaTime * speed);
        }
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
            {
                CheckForPlayer();
            }
        }
    }

    private void CheckForPlayer()
    {
        direction = -transform.up; // Only check downward direction

        Debug.DrawRay(transform.position, direction * range, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, range, playerLayer);

        if (hit.collider != null && !attacking)
        {
            attacking = true;
            destination = direction;
            checkTimer = 0;
        }
    }

    private void Stop()
    {
        destination = transform.position; // Set destination as current position so it doesn't move
        attacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Stop(); // Stop spikehead once he hits something
    }
}
