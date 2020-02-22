using UnityEngine.UI;
using UnityEngine;

public class Options_Menu : MonoBehaviour
{
    public Toggle Touch_Toggle;
    public Toggle Move_Toggle;
    public AudioSource audioSource;
    private float volumeLevel;
    public Slider volumeSlider;
    private void Awake()
    {
        volumeLevel = PlayerPrefs.GetFloat("VolumeLevel");
        audioSource.volume = volumeLevel;
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeLeve",0.5f);

        if (PlayerPrefs.HasKey("Control"))
        {
            switch (PlayerPrefs.GetString("Control"))
            {
                case "Touch":
                    Touch_Toggle.isOn = true;
                    BehaviourScript.Control_Mode_Touch = true;
                    break;
                case "Move":
                    Move_Toggle.isOn = true;
                    BehaviourScript.Control_Mode_Touch = false;
                    break;
            }
        }
        else 
        {
            return;
        }
    }
    private void FixedUpdate()
    {

        Debug.Log("Behave Control Mode :" + BehaviourScript.Control_Mode_Touch);
        
        Debug.Log("pref Control Mode :" + PlayerPrefs.GetString("Control"));

        volumeLevel = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeLevel",volumeLevel);
        audioSource.volume = volumeLevel;

    }

    #region Control Mapping
    public void Set_Touch_Toggle_True()
    {
        BehaviourScript.Control_Mode_Touch = true;
        PlayerPrefs.SetString("Control","Touch");
    }

    public void Set_Move_Toggle_True()
    {
        BehaviourScript.Control_Mode_Touch = false;
        PlayerPrefs.SetString("Control","Move");
    }

    #endregion Control Mapping

    #region Reset Score
    public void ResetScore()
    {
        PlayerPrefs.SetInt("level1",0);
        PlayerPrefs.SetInt("level2",0);
        PlayerPrefs.SetInt("level3",0);
        PlayerPrefs.SetInt("level4",0);
        PlayerPrefs.SetString("Control","");

    }
    #endregion Reset Score

    public void savePrefrences()
    {
        PlayerPrefs.Save();
    }
}
