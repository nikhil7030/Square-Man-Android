using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BehaviourScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public GameObject distroyedObjextsRed;
    public GameObject distroyedObjextsGreen;
    public AudioClip boom;
    public AudioSource audioSource;
    public float move = 135f, fmove = 1000f;
    public float Speed = 55f;
    public static bool Control_Mode_Touch = true;
    public score2 score2;
    public int hit_value = 6;
    public Slider hit_Count;
    public Slider powerUp;
    public float previousTime;
    [SerializeField]private float timeGap = 4f;
    [SerializeField] private speed sp;
    public float temp = 0;  //Speed
    public float store_score = 0;
    public float previousPosition;
    private bool isLost;
    public Gradient healthGreadient;
    public Gradient powerUpGradient;
    public Image[] fill = new Image[2];
    int a, b, c, d;

    void Awake()
    {
        a = PlayerPrefs.GetInt("Level 1");
        b = PlayerPrefs.GetInt("Level 2");
        c = PlayerPrefs.GetInt("Level 3");
        d = PlayerPrefs.GetInt("Level 4");
        
        Debug.Log(SceneManager.GetActiveScene().name);
        Debug.Log("Start");
        rb = GetComponent<Rigidbody>();
        isLost = false;
        fill[0].color = healthGreadient.Evaluate(1f);    //Health
        fill[1].color = powerUpGradient.Evaluate(1f);    //Power    
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ground" || col.gameObject.tag == "Boundary" || col.gameObject.tag == "Distroyed Objects")
        {
            //To Skip Ground collision Count
        }
        else
        {
            audioSource.PlayOneShot(boom);
            hit_value -= 1; //Adds The Hit Count & Reducing Min Hit Allowded
            hit_Count.value = hit_value;
            if(hit_value > 0)
            {
                col.gameObject.GetComponent<MeshRenderer>().enabled = false;
                col.gameObject.GetComponent<BoxCollider>().enabled = false;
                if(col.gameObject.tag == "Green Obstracles")
                {
                    Instantiate(distroyedObjextsGreen,col.transform);
                }
                else
                {
                    Instantiate(distroyedObjextsRed,col.transform);
                }
                
            }
        }

    }

    #region Touch Input
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

    #endregion Touch Input
    void FixedUpdate()
    {
        #region Keyboard Input
        if (Input.GetKey("a"))
        {
            if (Control_Mode_Touch)
            {
                rb.AddForce(-50f * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                // Debug.Log("Going Left");
                //For Left Movement
            }
        }
        if (Input.GetKey("d"))
        {
            if (Control_Mode_Touch)
            {
                rb.AddForce(50f * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                //Debug.Log("Going Right");
                //For Right Movement
            }
        }

        #endregion Keyboard Input

        #region Acceleromitor Input
        if (Control_Mode_Touch == false)
        {
            Vector3 acc = Input.acceleration;
            rb.AddForce(acc.x * Speed, 0, 0);
            //Debug.Log("Accelerometer Position" + acc.x);
        }

        #endregion Acceleromitor Input

        rb.AddForce(0, 0, fmove * Time.deltaTime);

        #region GameOver If Falls
        if (rb.position.y < -2)
        {
            if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0) >= score2.x && !isLost)
            {
                transform.GetComponent<Rigidbody>().isKinematic= true;
                Instantiate(distroyedObjextsRed,transform);
                audioSource.PlayOneShot(boom);
                this.GetComponent<MeshRenderer>().enabled = false;
                this.GetComponent<BoxCollider>().enabled = false;
                this.GetComponent<Rigidbody>().mass = 0;
                animator.SetTrigger("Lost_Fade");
                isLost = true;
                score2.x = 0;
                Debug.Log("Aw Shit Here We Go Again");
            }
            else if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0) < score2.x)
            {
                
                animator.SetTrigger("Fade_Out");
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name,score2.x);
            }
            PlayerPrefs.Save();
        }
        #endregion GameOver If Falls

        #region GameOver If Get hit
        if (hit_value <= 0)
        {
            if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0) >= score2.x && !isLost)
            {
                transform.GetComponent<Rigidbody>().isKinematic = true;
                Instantiate(distroyedObjextsRed,transform);
                this.GetComponent<MeshRenderer>().enabled = false;
                this.GetComponent<BoxCollider>().enabled = false;
                this.GetComponent<Rigidbody>().mass = 0;
                animator.SetTrigger("Lost_Fade");
                isLost = true;
                score2.x = 0;

                Instantiate(distroyedObjextsRed,transform);
                this.GetComponent<MeshRenderer>().enabled = false;
                this.GetComponent<BoxCollider>().enabled = false;
                this.GetComponent<Rigidbody>().mass = 0;
                //Debug.Log("This is from behave Stating Lost");
            }
            else if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0) < score2.x)
            {
                animator.SetTrigger("Fade_Out");
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, score2.x);

            }
            PlayerPrefs.Save();
        }
        #endregion GameOver If Get hit

        #region GameOver If Stuck
        if (Time.time - previousTime > timeGap)
        {
            if (transform.position.z == previousPosition)
            {
                if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0) >= score2.x && !isLost)
                {
                    transform.GetComponent<Rigidbody>().isKinematic = true;
                    Instantiate(distroyedObjextsRed,transform);
                    audioSource.PlayOneShot(boom);
                    this.GetComponent<MeshRenderer>().enabled = false;
                    this.GetComponent<BoxCollider>().enabled = false;
                    this.GetComponent<Rigidbody>().mass = 0;
                    animator.SetTrigger("Lost_Fade");
                    isLost = true;
                    score2.x = 0;

                    //Debug.Log("This is from behave Stating Lost");
                }
                else if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0) < score2.x)
                {
                    animator.SetTrigger("Fade_Out");
                    PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, score2.x);
                }
            }
            fmove += 70f;
            Speed += 1.5f;
            temp += 1;
            move +=2; 
            sp.speed_.text = "X" + temp;
            previousTime = Time.time;
            previousPosition = transform.position.z;
            PlayerPrefs.Save();
        }

        #endregion GameOver If Stuck

       
        fill[0].color = healthGreadient.Evaluate(hit_Count.normalizedValue);
        fill[1].color = powerUpGradient.Evaluate(powerUp.normalizedValue);
    }
}


