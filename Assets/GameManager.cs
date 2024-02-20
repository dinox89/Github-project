using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject AdsIcone;
    public GameObject player;
    public GameObject healthObject;
    public GameObject healthbarObject;
    public GameObject coinObject;
    public GameObject fruitObject;
    public GameObject DPADObject;
    public GameObject BObject;
    public GameObject YObject;
    public GameObject coinTextObject;
    public GameObject fruitTextObject;
    public GameObject fruit2TextObject;
    public AudioSource musiquePrincipale;
    [SerializeField] private AudioClip Sound;

    [SerializeField] private AudioClip Mainmenusound;
    [SerializeField] private AudioClip Restartsound;


    public void Restart()
    {
        Time.timeScale = 1;
        GameObject debCheckpoint = GameObject.FindWithTag("DEB"); // Trouvez le checkpoint au début du niveau
        if (debCheckpoint != null)
        {
            PlayerMovement.lastCheckpointposition = debCheckpoint.transform.position;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }





    public void gameOver()
    {
        SoundManager.instance.PlaySound(Sound);
        musiquePrincipale.Stop();
        gameOverUI.SetActive(true);
        healthObject.SetActive(false);
        healthbarObject.SetActive(false);
        coinObject.SetActive(false);
          
        fruitObject.SetActive(false);
        DPADObject.SetActive(false);
        BObject.SetActive(false);
        YObject.SetActive(false);
        fruitTextObject.SetActive(false);
        coinTextObject.SetActive(false);
        fruit2TextObject.SetActive(false);







    }





    public void MainMenu()
    {
        SoundManager.instance.PlaySound(Mainmenusound);
        SceneManager.LoadScene("MainMenu");
    }



    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }



}