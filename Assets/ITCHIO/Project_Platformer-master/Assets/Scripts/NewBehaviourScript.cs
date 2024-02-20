using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    public GameObject playerOnPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.CompareTag("Player"))
        {
            playerOnPlatform = player;
            player.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (player == playerOnPlatform)
        {
            playerOnPlatform = null;
            player.transform.SetParent(null);
        }
    }

    private void Update()
    {
        if (playerOnPlatform != null)
        {
            // Vous pouvez effectuer ici toute action spécifique que vous souhaitez pour le joueur sur la plateforme.
            // Par exemple, ajuster la position du joueur avec la plateforme ou autre.
        }
    }
}
