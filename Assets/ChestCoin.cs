using UnityEngine;

public class ChestCoin : MonoBehaviour
{
    public float jumpHeight = 2f; // Hauteur maximale du saut
    public float timeToJumpApex = 0.5f; // Temps pour atteindre la hauteur maximale du saut
    public AnimationCurve jumpCurve; // Courbe d'animation du saut

    private float gravity; // Gravité appliquée à la pièce
    private float jumpVelocity; // Vitesse initiale du saut
    private float timeElapsed; // Temps écoulé depuis le début de l'animation

    private Vector2 startPosition; // Position de départ de la pièce
    [SerializeField] private AudioClip pickupSound;
    private CoinManager coinManager;
    private bool isGrounded; // Indique si la pièce est au sol

    private Rigidbody2D rb2d;
    private BoxCollider2D coll2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll2d = GetComponent<BoxCollider2D>();
        coinManager = FindObjectOfType<CoinManager>();

        // Calculer la gravité en utilisant la formule du mouvement vertical : gravity = (2 * jumpHeight) / (timeToJumpApex ^ 2)
        gravity = (2f * jumpHeight) / Mathf.Pow(timeToJumpApex, 2f);

        // Calculer la vitesse initiale du saut en utilisant la formule du mouvement vertical : jumpVelocity = gravity * timeToJumpApex
        jumpVelocity = gravity * timeToJumpApex;

        startPosition = rb2d.position;
        timeElapsed = 0f;
    }

    private void Update()
    {
        // Mettre à jour le temps écoulé
        timeElapsed += Time.deltaTime;

        // Obtenir la proportion du temps écoulé par rapport à la durée totale de l'animation
        float t = timeElapsed / timeToJumpApex;

        // Évaluer la courbe d'animation du saut pour obtenir la hauteur Y correspondante
        float jumpHeightValue = jumpCurve.Evaluate(t) * jumpHeight;

        // Calculer la position de la pièce en utilisant le mouvement vertical
        Vector2 newPosition = startPosition;
        newPosition.y += jumpHeightValue - (0.5f * gravity * Mathf.Pow(t, 2f));

        // Vérifier si la pièce est au sol
        Collider2D[] colliders = Physics2D.OverlapBoxAll(newPosition, coll2d.size, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.CompareTag("Ground"))
            {
                newPosition.y = collider.bounds.max.y; // Ajuster la position de la pièce pour ne pas passer à travers le sol
                break;
            }
        }

        // Mettre à jour la position de la pièce
        rb2d.MovePosition(newPosition);
    }
}
