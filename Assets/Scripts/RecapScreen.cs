using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecapScreen : MonoBehaviour
{
    public TMP_Text coinsCountTextMesh;
    public TMP_Text fruitCountTextMesh;
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
    public int fruitCollected = 0;
    public int coinsCollected = 0;
    public Image coinsImage;
    public TMP_Text victoryTextMesh;
    public Image fruitsImage;

    public Inventory inventory;
    public GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void UpdateValues()
    {
        int fruitCount = inventory.fruitCount;
        int coinCount = inventory.coinsCount;

        coinsCountTextMesh.text = "Coins Collected: " + coinCount;
        fruitCountTextMesh.text = "Fruit Collected: " + fruitCount;
        coinsImage.gameObject.SetActive(coinCount > 0);
        fruitsImage.gameObject.SetActive(fruitCount > 0);
    }

    public void Show()
    {
       
        panel.SetActive(true);
        coinsCountTextMesh.transform.SetParent(panel.transform, false);
        fruitCountTextMesh.transform.SetParent(panel.transform, false);
        DPADObject.SetActive(false);
        BObject.SetActive(false);
        YObject.SetActive(false);
        healthObject.SetActive(false);
        healthbarObject.SetActive(false);
        coinObject.SetActive(false);
        
        fruitObject.SetActive(false);
       
        fruitTextObject.SetActive(false);
        coinTextObject.SetActive(true);
        fruit2TextObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int fruitCount = inventory.fruitCount;
            int coinCount = inventory.coinsCount;
            UpdateValues();
            Show();
        }
    }
}
