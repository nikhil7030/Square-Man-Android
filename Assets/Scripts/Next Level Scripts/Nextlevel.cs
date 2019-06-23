
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextlevel : MonoBehaviour
{
    GameManager Gamemanager;
    public int Next_Level_ToCome;
    public void Next_Level()
    {
        
        SceneManager.LoadScene(Next_Level_ToCome);
        Gamemanager.Store_Score = 0;
        score2.x = 0;
    }
    
}
