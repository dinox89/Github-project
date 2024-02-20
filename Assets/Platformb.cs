using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformb : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private bool isPlayerOnPlatform = false;
    private Transform playerTransform;
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        // Déplacer la plateforme vers le prochain waypoint
        if (waypoints.Length > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, Time.deltaTime * speed);

            if (Vector2.Distance(waypoints[currentWaypointIndex].position, transform.position) < .1f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }

        // Si le joueur est sur la plateforme, le déplacer avec elle
        if (isPlayerOnPlatform && playerTransform != null)
        {
            Vector3 deltaMovement = transform.position - playerTransform.position;
            playerTransform.position += deltaMovement;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            playerTransform = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
            playerTransform = null;
        }
    }
}
