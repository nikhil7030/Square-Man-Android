
using UnityEngine;

public class Lost_Script : MonoBehaviour
{
    void Fade_When_Lost()
    {
            FindObjectOfType<GameManager>().restart();
            //Function To Restart The Level if player Falls out

    }
}
