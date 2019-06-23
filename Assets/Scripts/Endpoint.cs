using UnityEngine;

public class Endpoint : MonoBehaviour
{
    public GameManager gamemanger;
    public void OnTriggerEnter()
    {
        gamemanger.complete_level1();
    }
}
