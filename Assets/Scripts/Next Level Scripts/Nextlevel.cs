
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextlevel : MonoBehaviour
{
    score2 score2;
    public int Next_Level_ToCome;
    public void Next_Level()
    {
        
        SceneManager.LoadScene(Next_Level_ToCome);
        score2.Store_score = 0;
        score2.x = 0;
    }
    
}
