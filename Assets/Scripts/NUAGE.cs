using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NUAGE : MonoBehaviour
{
    public Transform player; // Référence au transform du joueur
    public float parallaxSpeed = 0.5f; // Vitesse de déplacement du fond
    public float offsetY = 0f;


    private Vector2 lastPlayerPos;      // Position du joueur au dernier frame

    void Start()
    {
        lastPlayerPos = player.position;
    }

    void FixedUpdate()
    {
        // Calculer le déplacement du joueur depuis le dernier frame en utilisant Time.deltaTime
        float deltaX = parallaxSpeed * Time.deltaTime;
        float deltaY = 0;
  ;
        transform.position = new Vector3(transform.position.x, player.position.y + offsetY, transform.position.z);
        // Mettre à jour la position du fond en fonction du déplacement calculé
        transform.position = new Vector3(transform.position.x + deltaX, transform.position.y + deltaY, transform.position.z);
    }
}