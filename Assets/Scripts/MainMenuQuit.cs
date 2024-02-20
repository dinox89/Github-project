using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuQuit : MonoBehaviour
{
    [SerializeField] private AudioClip deathsound;

    public void Quit()
    {
        SoundManager.instance.PlaySound(deathsound);
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
