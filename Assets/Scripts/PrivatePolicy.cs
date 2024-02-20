using UnityEngine;

public class PrivatePolicy : MonoBehaviour
{
    public string url = "https://sites.google.com/view/dragonsodysseyprivacy-policy/accueil";

    public void OpenLink()
    {
        Application.OpenURL(url);
    }
}
