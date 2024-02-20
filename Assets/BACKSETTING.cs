using UnityEngine;

public class BACKSETTING : MonoBehaviour
{
    [SerializeField]
    private GameObject[] elementsToHide;

    public GameObject Setting;
    public GameObject SettingIconne;
    public GameObject Titre1;
    public GameObject INSTA;
    public GameObject Jaime;
    public GameObject Play;
 


    private bool settingsPanelActive = false;

    public void ToggleSettingsPanel()
    {
        Setting.SetActive(!settingsPanelActive);
        settingsPanelActive = !settingsPanelActive;

        foreach (GameObject element in elementsToHide)
        {
            element.SetActive(settingsPanelActive);
            Setting.SetActive(false);
            SettingIconne.SetActive(true);
            Titre1.SetActive(true);
            INSTA.SetActive(true);
            Jaime.SetActive(true);
            Play.SetActive(true);
            
        }
    }
}
