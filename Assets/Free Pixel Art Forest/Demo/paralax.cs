using UnityEngine;

public class paralax : MonoBehaviour
{
    public Transform player;                // Référence au transform du joueur
    public float parallaxSpeed = 0.5f;      // Vitesse de déplacement du fond
    public float offsetY = 0f;              // Offset de la position verticale du fond

    private Vector3 lastPlayerPos;          // Position du joueur au dernier frame

    void Start()
    {
        lastPlayerPos = player.position;
    }

    void FixedUpdate()
    {
        // Calculer le déplacement du joueur depuis le dernier frame
        Vector3 playerDelta = player.position - lastPlayerPos;

        // Calculer le déplacement à appliquer au fond en fonction de la vitesse de déplacement et du déplacement du joueur
        Vector3 parallaxDelta = new Vector3(playerDelta.x, playerDelta.y, 0f) * parallaxSpeed;

        // Mettre à jour la position du fond en fonction du déplacement calculé
        transform.position += parallaxDelta;
        transform.position = new Vector3(transform.position.x, player.position.y + offsetY, transform.position.z);

        // Mettre à jour la dernière position du joueur
        lastPlayerPos = player.position;
    }
}