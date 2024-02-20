using UnityEngine;

public class SpiKe : MonoBehaviour
{
    // Vitesse de rotation de la boule de pique
    public float rotationSpeed = 50f;

    // Rayon de la trajectoire circulaire
    public float radius = 2f;

    // Angle initial de la boule de pique sur la trajectoire circulaire
    public float initialAngle = 90f;

    // Fonction appelée à chaque frame
    void Update()
    {
        // Calcul de l'angle de rotation en fonction du temps et de la vitesse de rotation
        float angle = initialAngle + Time.time * rotationSpeed;

        // Conversion de l'angle en radians
        float angleRad = angle * Mathf.Deg2Rad;

        // Calcul des coordonnées de la boule de pique en fonction de l'angle et du rayon
        float xPos = Mathf.Cos(angleRad) * radius;
        float zPos = Mathf.Sin(angleRad) * radius;

        // Positionnement de la boule de pique
        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }

    // Méthode pour régler la vitesse de rotation
    public void SetRotationSpeed(float speed)
    {
        rotationSpeed = speed;
    }

    // Méthode pour régler le rayon de la trajectoire
    public void SetRadius(float r)
    {
        radius = r;
    }

    // Méthode pour régler l'angle initial de la boule de pique sur la trajectoire circulaire
    public void SetInitialAngle(float angle)
    {
        initialAngle = angle;
    }
}
