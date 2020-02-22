
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public TextMeshProUGUI[] score = new TextMeshProUGUI[3];

    private void Awake() 
    {
        score[0].SetText(PlayerPrefs.GetInt("level1",0).ToString());
        score[1].SetText(PlayerPrefs.GetInt("level2",0).ToString());
        score[2].SetText(PlayerPrefs.GetInt("level3",0).ToString());
        score[3].SetText(PlayerPrefs.GetInt("level4",0).ToString()); 

        
    }
    private void Update()
    {
       /* if (PlayerPrefs.GetInt("level1") >= 2000)
        {
            level2.interactable = true;
        }
        else
        {
            level2.interactable = false;
        }

        if (PlayerPrefs.GetInt("level2") >= 3000)
        {
            level3.interactable = true;
        }
        else
        {
            level2.interactable = false;
        }

        if (PlayerPrefs.GetInt("level3") >= 4000)
        {
            level4.interactable = true;
        }
        else
        {
            level2.interactable = false;
        }*/
        
    }
    
    public void Play(int level)
    {
        SceneManager.LoadSceneAsync(level);
    }
    public void Quit()
    {
        Application.Quit();
    }
    

}
