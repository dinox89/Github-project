using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2 : MonoBehaviour
{
    public string Level2;

    public void LoadLevel(int index)
    {
        

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerMovement.lastCheckpointposition = new Vector2(17.31f, -7.71f);
        }

        Time.timeScale = 1;
        SceneManager.LoadScene("Level 2");

    }

}
