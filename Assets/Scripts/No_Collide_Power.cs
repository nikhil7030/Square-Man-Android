using UnityEngine;
using System.Collections;


public class No_Collide_Power : MonoBehaviour
{
    //public Transform Player;
    public GameObject PowerUp_Effect;
    public ParticleSystem Partical;
    public int Power_Duration = 5;
    public GameObject[] Obst;
    public Pause pause;
    public Transform Player;
    Vector3 add = new Vector3(0.2f,.2f,.2f);

   
    
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(PickUp());
            StartCoroutine(pause.Update_PowerUp_Bar());
        }
    }
    IEnumerator PickUp()
    {

        //Debug.Log("Triggered");

        Partical.Play();    //Add PowerUp Effect
        Obst = GameObject.FindGameObjectsWithTag("Obstracle"); 

        foreach (GameObject r in Obst)
        {
            //Debug.Log("Disabled");
            r.GetComponent<BoxCollider>().enabled = false; //Part After Getting PowerUp

        
        }
        
        Player.transform.localScale += add;
        
            
        yield return new WaitForSeconds(Power_Duration);


        Partical.Stop();
        Player.transform.localScale -= add;
        foreach (GameObject r in Obst)
        {
            //Debug.Log("Disabled");
            r.GetComponent<BoxCollider>().enabled = true; //Part After Loosing PowerUp

        }


        //Debug.Log("Distroyed");
        Destroy(gameObject);
    }
    
}
