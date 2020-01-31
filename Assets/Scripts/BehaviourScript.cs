using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BehaviourScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public float move = 100f, fmove = 1000f;
    public float Speed = 0f;
    public static bool Control_Mode_Touch = true;
    public score2 score2;
    public int hit_value = 6;
    public Slider Hit_Count;




    void Start()
    {
        Debug.Log("Start");
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ground" || col.gameObject.tag == "Boundary")
        {
            //To Skip Ground collision Count
        }
        else
        {
            hit_value -= 1; //Adds The Hit Count & Reducing Min Hit Allowded
            Hit_Count.value = hit_value;
            
        }

    }

    public void Move_Left()
    {
        if (Control_Mode_Touch)
        {
            rb.AddForce(-move * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            // Debug.Log("Going Left");
            //For Left Movement
        }
    }
    public void Move_Right()
    {
        if (Control_Mode_Touch)
        {
            rb.AddForce(move * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            //Debug.Log("Going Right");
            //For Right Movement
        }
    }

    void Update()
    {
        
        rb.AddForce(0, 0, fmove * Time.deltaTime);
        if (rb.position.y < -2)
        {
                animator.SetTrigger("Lost_Fade");
            
        }

    }
    void FixedUpdate()
    {
        if (Control_Mode_Touch == false)
        {
            Vector3 acc = Input.acceleration;
            rb.AddForce(acc.x * Speed, 0, 0);
            Debug.Log("Accelerometer Position" + acc.x);
        }

        if (hit_value <= 0)
        {
            animator.SetTrigger("Lost_Fade");
        }
    }


   
}


