
using UnityEngine;
using UnityEngine.UI;

public class score2: MonoBehaviour
{
    public Transform Player;
    public Transform End_Point; 

    [SerializeField] private Text Textscore; //To Update Score in Canvas
    [SerializeField] private Text HighScore; //To Update HighScore in Canvas
    public int x = 0;  //Score var
    public int Store_score = 0; 
    public int previous_Score = 0; 
    Vector3 previous_possition,current_postion; 
    
    // Start is called before the first frame update
    void Start()
    {
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("Score", 0).ToString();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
            current_postion.z = Player.position.z;

            if(current_postion.z != previous_possition.z)
            {
                    if (Player.position.z < End_Point.position.z)
                    {
                        x += 1;
                        previous_possition.z = Player.position.z;
                        //Debug.Log("previous :" + previous_possition.z);
                        //Debug.Log("current :" + current_postion.z);
                        //Debug.Log("Player.position :" + Player.position.z);
                    }
                    Textscore.text = "Score : " + x;
            }
            Store_score = x;
        if (PlayerPrefs.GetInt("Score", 0) == 0)
        {
            PlayerPrefs.SetInt("Score", Store_score);
        }
        
        if (PlayerPrefs.GetInt("Score",0) < Store_score)
        {
            PlayerPrefs.SetInt("Score", Store_score);
        }
    }

}

