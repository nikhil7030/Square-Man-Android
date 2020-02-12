
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public score2 score2;
    public int Current_Scene;
    
    public void restart() //Scean Restart
    {
        SceneManager.LoadScene("Lost");
        score2.Store_score = 0;
    }

    public void Replay_Current_Level()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void Replay_Current_Level_from_Lost()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    




}
