using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 CameraPosition;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.position + CameraPosition;
    }
}
