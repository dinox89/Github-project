using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class musicslider : MonoBehaviour
{
    public Slider slider;
    public AudioMixer mixer;


    public void SetMusic()
    {
        mixer.SetFloat("volume", slider.value);
    }
}
