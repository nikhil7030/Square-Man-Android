
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private static bool isgamepaused = false;
    public Transform Player; // Postion Of Player
    public Transform End_Point; // Postion Of End Line
    public Slider Progress_Bar;
    public Slider PowerUp_Bar;
    int i,Temp_Slider_Value = 10;
    public GameObject lostPanel;
    public GameObject blurPanel;

    void Awake()
    {
        Progress_Bar.maxValue = End_Point.position.z; // To Set Max Progressbar Value
        Progress_Bar.minValue = Player.position.z; // To Set Max Progressbar Value
        lostPanel.SetActive(false);
        blurPanel.SetActive(false);
        Debug.Log("This is from Pause Disabling panels");
    }
    void Update()
    {
        
        Progress_Bar.value = Player.position.z; // To Update Progress Bar
        
    }

    public void exit()
    {
        Application.Quit(); 
    }

    public void Back_button()
    {
        SceneManager.LoadScene("Menu");  //Going Back To Menu
    }

    public void resume() // Resuming Game
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

    public void pause() // Pausing Game
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

    public IEnumerator Update_PowerUp_Bar()
    {
        Debug.Log("Entered In Function");
        for (i=0; i < 10;i++ )
        {
            Temp_Slider_Value -=  1;
            PowerUp_Bar.value = Temp_Slider_Value;
            Debug.Log("Sec "+ Temp_Slider_Value);
            yield return new WaitForSeconds(1f);

        }
    }
    
}
