using UnityEngine;
using UnityEngine.SceneManagement;

public class level_Transition : MonoBehaviour
{
    public Animator animator;
    public score2 scoreref;
    public BehaviourScript behave;
    [SerializeField]private GameObject[] lostPanel = new GameObject[2];
    
    public int Next_Level_Index;
    public void End_Game_Animation()
    {
        animator.SetTrigger("Fade_Out");
    }
    public void complete_level1()
    {
        //Debug.Log("End Point Reached");
        SceneManager.LoadSceneAsync(0);
        behave.hit_value = 0;
        scoreref.x = 0;

    }
    public void Fade_When_Lost()
    {
        //Debug.Log("This is from levelTransition Enabling panels");
        lostPanel[0].SetActive(true);
        lostPanel[1].SetActive(true);
        
    }

    public void startGameAnimation()
    {
        lostPanel[0].SetActive(false);
        lostPanel[1].SetActive(false);
        //Debug.Log("This is from levelTransition Disabling panels");
    }

}
