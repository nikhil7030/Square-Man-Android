
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private static bool isgamepaused = false;
    public void exit()
    {
        Application.Quit();
    }
    public void Back_button()
    {
        SceneManager.LoadScene("Menu");
    }
    public void resume()
    {
        if (isgamepaused == true)
        {
            Time.timeScale = 1.0f;
            isgamepaused = false;
        }
        else
        {
            Time.timeScale = 0.0f;
        }

    }
    public void pause()
    {
        if (isgamepaused == false)
        {
            Time.timeScale = 0.0f;
            isgamepaused = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            isgamepaused = false;
        }
    }
    
}
