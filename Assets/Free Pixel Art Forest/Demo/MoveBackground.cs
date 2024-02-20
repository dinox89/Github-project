using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public Transform player;            // Référence au transform du joueur
    public float parallaxSpeed = 0.5f;  // Vitesse de déplacement du fond
    public float offsetY = 0f;          // Offset en Y à appliquer lorsque le joueur a sauté une fois

    private Vector2 lastPlayerPos;      // Position du joueur au dernier frame
   

    void Start()
    {
        lastPlayerPos = player.position;
    }

    void FixedUpdate()
    {
        // Calculer le déplacement du joueur depuis le dernier frame
        float deltaX = player.position.x - lastPlayerPos.x;
        float deltaY = player.position.y - lastPlayerPos.y;

        // Calculer le déplacement à appliquer au fond en fonction de la vitesse de déplacement et du déplacement du joueur
        float parallaxDeltaX = deltaX * parallaxSpeed;
        float parallaxDeltaY = deltaY * parallaxSpeed;

        // Mettre à jour la position du fond en fonction du déplacement calculé
        Vector2 newPos = transform.position + new Vector3(parallaxDeltaX, parallaxDeltaY, 0f);

    
    }
}
