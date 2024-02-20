using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ENDFRUIT : MonoBehaviour
{
    public GameObject fruitTextObject;
    public GameObject panelvictorytext;
    public Inventory inventory;
   
    public TMP_Text fruitCountTextMesh;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            panelvictorytext.SetActive(true);
            TMP_Text fruitCountTextMesh = panelvictorytext.GetComponentInChildren<TMP_Text>();
            fruitCountTextMesh.text = Inventory.instance.fruitCountTextMesh.text;

        }
    }
}
