using UnityEngine;
using UnityEngine.SceneManagement;

public class BehaviourScript : MonoBehaviour
{
    public Rigidbody rb;
    public float move = 100,fmove = 1000;
  


    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ground" || col.gameObject.tag =="Boundary")
        {
            //To Skip Ground collision Count
        }
        else
        {
            Hit.hitValue += 1; //Adds The Hit Count
            score2.x -= 50; //Reduces Score if Hit 

            Debug.Log("Hit");
        }
        
        
    }

    public void Move_Left()
    {
        rb.AddForce(-move * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // Debug.Log("Going Left");
        //For Left Movement
    }
    public void Move_Right()
    {
            rb.AddForce(move* Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            //Debug.Log("Going Right");
            //For Right Movement
    }

void Update()
    {
        rb.AddForce(0, 0, fmove * Time.deltaTime);
        if (rb.position.y < -1)
        {
            FindObjectOfType<GameManager>().restart();
            //Function To Restart The Level if player Falls out

        }

       

    }
}
