using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private AudioClip Sound;
    public AudioSource musiquePrincipale;
    public Inventory inventory;


    public GameObject healthObject;
    public GameObject healthbarObject;
    public GameObject coinObject;
    public GameObject panelvictorytext;
    public GameObject fruitObject;
    public GameObject DPADObject;
    public GameObject BObject;
    public GameObject YObject;
    public GameObject panel;
    public GameObject Recappanel;
    public GameObject HomeButton;
    public GameObject Quitbutton;
    public GameObject coinTextObject;
    public GameObject fruitTextObject;
    public GameObject fruit2TextObject;
    public GameObject pause;




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

           

            musiquePrincipale.Stop();
            SoundManager.instance.PlaySound(Sound);
            panelvictorytext.SetActive(true);
            //// PIECE
            TMP_Text coinsCollectedText = panelvictorytext.GetComponentInChildren<TMP_Text>();
            coinsCollectedText.text = Inventory.instance.coinsCount.ToString();
            // Mise à jour du texte des objets de texte des fruits
            TMP_Text fruitCollectedText = fruitTextObject.GetComponent<TMP_Text>();
            fruitCollectedText.text = Inventory.instance.fruitCount.ToString();
            healthObject.SetActive(false);
            healthbarObject.SetActive(false);
            coinObject.SetActive(false);
            panelvictorytext.SetActive(true);
            fruitObject.SetActive(false);
            DPADObject.SetActive(false);
            BObject.SetActive(false);
            YObject.SetActive(false);
            fruitTextObject.SetActive(false);
            coinTextObject.SetActive(false);
            fruit2TextObject.SetActive(false);
            pause.SetActive(false);
            panel.SetActive(true);
            Recappanel.SetActive(true);
            HomeButton.SetActive(true);
            Quitbutton.SetActive(true);
            UnLockNewLevel();





        }

    }



    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void UnLockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.SetInt("Level2ImageUnlocked", 1); // Enregistre le déblocage de l'image du niveau 2
            PlayerPrefs.SetInt("Level3ImageUnlocked", 1); // Enregistre le déblocage de l'image du niveau 3


            PlayerPrefs.Save();

        }
    }




}
















