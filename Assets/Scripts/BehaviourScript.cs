using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BehaviourScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public float move = 100f, fmove = 1000f;
    public float Speed = 50f;
    public static bool Control_Mode_Touch = true;
    public score2 score2;
    public int hit_value = 6;
    public Slider Hit_Count;
    private float previousTime;
    [SerializeField]private float timeGap = 1f;
    [SerializeField] private speed sp;
    public float temp = 0;  //Speed
    public float Store_score = 0;

    void Awake()
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

    void FixedUpdate()
    {
        
        rb.AddForce(0, 0, fmove * Time.deltaTime);
        if (rb.position.y < -2)
        {
            if (PlayerPrefs.GetInt("Score") < score2.Store_score)
            {
                animator.SetTrigger("Lost_Fade");
            }
            else if (PlayerPrefs.GetInt("Score",0) > score2.Store_score)
            {
                animator.SetTrigger("Fade_Out");
            }

        }

    
        if (Control_Mode_Touch == false)
        {
            Vector3 acc = Input.acceleration;
            rb.AddForce(acc.x * Speed, 0, 0);
            Debug.Log("Accelerometer Position" + acc.x);
        }

        if (hit_value <= 0)
        {
            if (PlayerPrefs.GetInt("Score") < score2.Store_score)
            {
                animator.SetTrigger("Lost_Fade");
            }
            else if (PlayerPrefs.GetInt("Score") > score2.Store_score)
            {
                animator.SetTrigger("Fade_Out");
            }
            

        }

        if (Time.time - previousTime > timeGap)
        {
            fmove += 70f;
            Speed += 1;
            temp += 1;
            sp.speed_.text = "X" + temp;
            previousTime = Time.time;
        }
    }
}


