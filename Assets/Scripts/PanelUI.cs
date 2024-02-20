using UnityEngine;

public class PanelUI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] elementsToHide;

    public GameObject Setting;
    public GameObject Titre1;
    public GameObject INSTA;
    public GameObject Jaime;
    public GameObject Play;
    public GameObject Back;
    public GameObject Credits;
    public GameObject Privatepolicy;
    public GameObject Tiltesetting;
    public GameObject INPUT;

    private bool settingsPanelActive = false;

    public void ToggleSettingsPanel()
    {
        Setting.SetActive(!settingsPanelActive);
        settingsPanelActive = !settingsPanelActive;

        foreach (GameObject element in elementsToHide)
        {
            element.SetActive(settingsPanelActive);
            Setting.SetActive(false);
            Titre1.SetActive(false);
            INSTA.SetActive(false);
            Jaime.SetActive(false);
            Play.SetActive(false);
            Back.SetActive(true);
            Credits.SetActive(true);
            Privatepolicy.SetActive(true);
            Tiltesetting.SetActive(true);
            INPUT.SetActive(true);
        }
    }
}
