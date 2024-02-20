using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CREDITBACK : MonoBehaviour
{
    [SerializeField]
    private GameObject[] elementsToHide;

    public GameObject Credits;
    public GameObject PrivatePolicy;
    public GameObject Title;
    public GameObject Back;
    public GameObject Setting;







    private bool settingsPanelActive = false;

    public void ToggleSettingsPanel()
    {
        Setting.SetActive(!settingsPanelActive);
        settingsPanelActive = !settingsPanelActive;

        foreach (GameObject element in elementsToHide)
        {
            element.SetActive(settingsPanelActive);
            Setting.SetActive(false);
            Credits.SetActive(false);
            PrivatePolicy.SetActive(false);
            Title.SetActive(false);
            Back.SetActive(false);

        }
    }
}
