using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class character : MonoBehaviour
{
    public GameObject[] playerPrefs;
    int characterindex;
    public static Vector2 lastCheckpointposition = new Vector2(17.31f, -7.71f);

    public CinemachineVirtualCamera VCam;


    private void Awake()
    {
        characterindex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(playerPrefs[characterindex], lastCheckpointposition, Quaternion.identity);
        VCam.m_Follow = player.transform;

    }
}
