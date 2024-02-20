using UnityEngine;

public class FramerateController : MonoBehaviour
{
    public int targetFPS = 60; // Définis le FPS cible souhaité ici

    void Start()
    {
        Application.targetFrameRate = targetFPS; // Définis le FPS cible au démarrage
    }
}
