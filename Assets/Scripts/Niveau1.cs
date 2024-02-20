using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Utilisez explicitement le namespace UnityEngine.UI
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.UIElements;


public class Niveau1 : MonoBehaviour
{
    private GameObject buttonPositionSaverObject;
    private ButtonPositionSaver buttonPositionSaver;

    public float cinematicDuration = 5f; // Durée de la cinématique en secondes
    public string DINO; // Le nom de la scène de la cinématique
    public UnityEngine.UI.Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;

        }
    }


    private void Start()
    {
        buttonPositionSaverObject = GameObject.Find("YourButtonPositionSaverObjectName"); // Remplacez "YourButtonPositionSaverObjectName" par le nom de l'objet contenant le script ButtonPositionSaver si besoin

        if (buttonPositionSaverObject != null)
        {
            buttonPositionSaver = buttonPositionSaverObject.GetComponent<ButtonPositionSaver>();
            if (buttonPositionSaver != null)
            {
                buttonPositionSaver.LoadButtonPositions();
            }
        }
    }

    public void LoadLevel(int index)
    {
        if (buttonPositionSaver != null)
        {
            buttonPositionSaver.SaveButtonPositions();
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerMovement.lastCheckpointposition = new Vector2(17.31f, -7.71f);
        }

        Time.timeScale = 1;
        StartCoroutine(PlayCinematicAndLoadLevel(index));
    }

    private IEnumerator PlayCinematicAndLoadLevel(int index)
    {
        // Charger la scène de la cinématique
        SceneManager.LoadScene("DINO");

        // Attendez que la cinématique soit chargée
        yield return new WaitForSeconds(20f); // Vous pouvez augmenter le délai si nécessaire

        // Attendez la durée de la cinématique
        yield return new WaitForSeconds(cinematicDuration);

        // Charger le niveau 1
        SceneManager.LoadScene(index);
    }
}