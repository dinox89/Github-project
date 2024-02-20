using UnityEngine;

public class LEVELW1UI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] elementsToHide;

    public GameObject selectionnerniveau;
    public GameObject selectionnerniveau1;
    public GameObject selectionnerniveau2;
    public GameObject Chooseworld;
    public GameObject Setting;
    public GameObject insta;
   
    public GameObject Back;


    private bool settingsPanelActive = false;

    public void ToggleSettingsPanel()
    {
        Setting.SetActive(!settingsPanelActive);
        settingsPanelActive = !settingsPanelActive;

        foreach (GameObject element in elementsToHide)
        {
            element.SetActive(settingsPanelActive);
            Setting.SetActive(false);
            selectionnerniveau.SetActive(false);
            selectionnerniveau1.SetActive(false);
            selectionnerniveau2.SetActive(false);
            Chooseworld.SetActive(false);
            Back.SetActive(false);
            insta.SetActive(false);
        
        }
    }
}
