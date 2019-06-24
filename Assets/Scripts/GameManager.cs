
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float Store_Score;
    public int Next_Level_Index;
    public void restart() //Scean Restart
    {
        Store_Score = 0;
        SceneManager.LoadScene("Lost");
        
    }

    public void Replay_Current_Level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void complete_level1()
    {
        Debug.Log("End Point Reached");
        Store_Score = 0;
        SceneManager.LoadScene(Next_Level_Index);

    }

    
}
