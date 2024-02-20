using UnityEngine;
using UnityEngine.UI;

public class Level2ImageController : MonoBehaviour
{
    public Image level2Image; // Fait glisser l'image du niveau 2 ici depuis l'éditeur Unity

    private void Start()
    {
        int level2ImageUnlocked = PlayerPrefs.GetInt("Level2ImageUnlocked", 0);

        if (level2ImageUnlocked == 1)
        {
            // Change la couleur de l'image du niveau 2 en noir
            level2Image.color = Color.black;
        }
    }
}
