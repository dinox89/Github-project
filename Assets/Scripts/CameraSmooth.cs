using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
    public Transform target;  // Le transform du joueur
    public float maxX;        // La position maximale en X où la caméra doit être bloquée
    public float smoothCamera;  // La vitesse de déplacement de la caméra (valeur recommandée entre 0.1f et 1.0f)

    private bool isBlocked = false;  // Si la caméra est bloquée
    private Vector3 targetPosition; // Position cible de la caméra

    void Update()
    {
        if (!isBlocked && target.position.x >= maxX)
        {
            // Bloquer la caméra si la position du joueur atteint maxX
            isBlocked = true;
        }
        else if (isBlocked && target.position.x < maxX)
        {
            // Débloquer la caméra si le joueur retourne en arrière
            isBlocked = false;
        }

        // Suivre la hauteur du joueur, même si la caméra est bloquée
        targetPosition = new Vector3(isBlocked ? transform.position.x : target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothCamera * Time.deltaTime);
    }
}