using UnityEngine.UI;
using UnityEngine;

public class Options_Menu : MonoBehaviour
{
    GameObject Touch_Toggle;
    GameObject Move_Toggle;

    private void Start()
    {
        Touch_Toggle = GameObject.Find("Touch");
        Move_Toggle = GameObject.Find("Move");
    }
    public void Set_Move_Toggle_True()
    {
        Touch_Toggle.GetComponent<Toggle>().isOn = false;
        BehaviourScript.Control_Mode_Touch = false;
    }
    public void Set_Touch_Toggle_True()
    {
        
        Move_Toggle.GetComponent<Toggle>().isOn = false;
        BehaviourScript.Control_Mode_Touch = true;
    }
   
}
