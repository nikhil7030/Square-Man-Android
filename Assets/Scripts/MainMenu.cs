﻿
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void playClickSound()
    {
        
    }

}
