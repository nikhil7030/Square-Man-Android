using UnityEngine;

public class Endpoint : MonoBehaviour
{
    
    public level_Transition level;
    public void OnTriggerEnter()
    {
        level.End_Game_Animation();

    }
}
