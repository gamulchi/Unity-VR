using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//모든 불에 달려있는 함수

public class hit : MonoBehaviour
{
    public GameObject hitimage; //불에 닿으면 화면 변하는 이미지
    private float hitnum;   
    public GameObject GManager;
   
    // Start is called before the first frame update
    void Start()
    {
        GManager = GameObject.FindGameObjectWithTag("GameManager");
        hitimage = GameObject.FindGameObjectWithTag("Canvas").transform.Find("hitImage").gameObject;
        hitimage.SetActive(false);
        hitnum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (GManager.GetComponent<GamePlayManager>().IsGameEnd == false)
            {
                hitnum++;
                hitimage.SetActive(true);

                if (hitnum > 100)
                {
                    Debug.Log("쥬금");
                }
                Invoke("HitImageOn", 2);
                Invoke("SendingEndingSignal", 3);
            }
           
        }
    }
    void HitImageOn()
    {
        hitimage.SetActive(true);
       
    }
    void SendingEndingSignal()
    {
        GManager.GetComponent<GamePlayManager>().BodyBurn = true;
        GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
    }
}
