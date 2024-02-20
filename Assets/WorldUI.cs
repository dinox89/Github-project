using UnityEngine;

public class WorldUI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] elementsToHide;

    public GameObject Setting;
    public GameObject Titre1;
    public GameObject SettingIconne;
    public GameObject Jaime;
    public GameObject Play;
    public GameObject World;
    public GameObject selectionnerniveau;
    public GameObject selectionnerniveau1;
    public GameObject selectionnerniveau2;
    public GameObject Chooseworld;
    public GameObject Back;
    public GameObject insta;

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
            SettingIconne.SetActive(false);
            Jaime.SetActive(false);
            Play.SetActive(false);
            World.SetActive(true);
            selectionnerniveau.SetActive(true);
            selectionnerniveau1.SetActive(true);
            selectionnerniveau2.SetActive(true);
            Chooseworld.SetActive(true);
            Back.SetActive(true);
            insta.SetActive(false);
        }
    }
}