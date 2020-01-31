using UnityEngine;
using UnityEngine.SceneManagement;

public class level_Transition : MonoBehaviour
{
    public Animator animator;
    public score2 scoreref;
    public BehaviourScript behave;
    
    public int Next_Level_Index;
    public void End_Game_Animation()
    {
        animator.SetTrigger("Fade_Out");
    }
    public void complete_level1()
    {
        Debug.Log("End Point Reached");
        SceneManager.LoadScene(Next_Level_Index);
        behave.hit_value = 0;
        scoreref.x = 0;
        


    }
    void Fade_When_Lost()
    {
        FindObjectOfType<GameManager>().restart();
        //Function To Restart The Level if player Falls out

    }

}
