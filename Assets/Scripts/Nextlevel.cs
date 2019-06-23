
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextlevel : MonoBehaviour
{
    GameManager Gamemanager;
    public int Next_Level_ToCome;
    public void Next_Level()
    {
        Gamemanager.Store_Score = 0;
        SceneManager.LoadScene(Next_Level_ToCome);
    }
    
}
