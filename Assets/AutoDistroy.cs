using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDistroy : MonoBehaviour
{
    private float previousTime;
    private float timeGap = 4f;

    private void Awake()
    {
    
        previousTime = Time.time;
       
    }
    void Update()
    {
        if (Time.time - previousTime > timeGap)
        {
            Destroy(this.gameObject);

        previousTime = Time.time;
        }
    }
}
