using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jaime : MonoBehaviour
{
   public string url = "https://play.google.com/store/apps/details?id=com.topplay.dragonsodyssey&hl=en-US&ah=M_lU1nqo-9E_uKaPsGolt-ub2_U";


    public void OpenGooglePlay()
    {
        Application.OpenURL(url);
    }

}
