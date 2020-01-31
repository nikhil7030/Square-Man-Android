
using UnityEngine;
using UnityEngine.UI;

public class score2: MonoBehaviour
{
    public Transform Player;
    public Transform End_Point; 

    Text Textscore; //To Update Score in Canvas
    public float x = 0;  //Score var
    public float Store_score = 0; 
    Vector3 previous_possition,current_postion; 
     

    // Start is called before the first frame update
    void Start()
    {
        Textscore = GetComponent<Text>();

    }

    // Update is called once per frame

    void Update()
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

        
    }

}

