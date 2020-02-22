using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    public void openLink(string option)
    {
        if (option == "youtube")
        {
            Application.OpenURL("https://www.youtube.com/channel/UCa6BCdlGEt1In6N6zTowsBA");
        }
        if (option == "insta")
        {
            Application.OpenURL("https://www.instagram.com/nikhil_kasar7030/");
        }
        if (option == "facebook")
        {
            Application.OpenURL("https://www.facebook.com/Kasarnikhil.30");
        }
        if(option == "Web")
        {
            Application.OpenURL("https://nikhilneo7030.wordpress.com/");
        }

        
    }
}

