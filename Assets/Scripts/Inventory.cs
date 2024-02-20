using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public int fruitCount;

    public TMP_Text coinsCountTextMesh;
    public TMP_Text fruitCountTextMesh;
 

    public static Inventory instance;




    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il ny a plus ");
            return;
        }
        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountTextMesh.text = coinsCount.ToString();

    }

    public void Addfruit(int count)
    {
        fruitCount += count;
        fruitCountTextMesh.text = fruitCount.ToString();
    }

   

}
