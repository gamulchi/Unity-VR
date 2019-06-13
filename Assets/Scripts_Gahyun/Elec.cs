using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elec : MonoBehaviour
{
    public GameObject wa;
    
    public GameObject Smoke;
    public GameObject GManager;
    public GameObject EndingCanvas;
    // Start is called before the first frame update
    void Start()
    {
        EndingCanvas = GameObject.FindGameObjectWithTag("Canvas");
        if (!GManager)
        {
            GManager = GameObject.FindGameObjectWithTag("GameManager").gameObject;
        }
        if (!Smoke)
        {
            Smoke = GameObject.FindGameObjectWithTag("Smoke");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pot")
        {
            wa = other.gameObject.transform.Find("Cylinder").gameObject;
            if (wa.activeInHierarchy == true)
            {
                wa.SetActive(false);
                if (GManager.GetComponent<GamePlayManager>().IsGameEnd == false)
                {
                    GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
                    
                    GManager.GetComponent<GamePlayManager>().ElecDeath = true;
                }
            }
        }
        if (other.gameObject.tag == "Water")
        {
            if (GManager.GetComponent<GamePlayManager>().IsGameEnd == false)
            {
                GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
             
                GManager.GetComponent<GamePlayManager>().ElecDeath = true;
            }
        }
        if (other.gameObject.tag == "Ex_Water")
        {
            Winner.fireoff = true;
            
            StartCoroutine(Smoke.GetComponent<SmokeScript>().SmokeSmaller());
            Destroy(this.gameObject);
            GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
            Winner.fireoff = true;
        }
    }
}
