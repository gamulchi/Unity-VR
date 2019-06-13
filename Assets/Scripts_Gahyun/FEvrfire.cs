using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnExtinguisher : MonoBehaviour
{//소화액이랑 불이랑 닿았을때 -쇼파불 말고 다른거에만 사용하기
    public GameObject GManager;
    // Start is called before the first frame update
    void Start()
    {
        GManager = GameObject.FindGameObjectWithTag("GameManager").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //모든 불을 다 끔
        if(other.gameObject.tag == "Ex_Water")
        {
            Winner.fireoff = true;
            GManager.GetComponent<GamePlayManager>().IsGameEnd = true;

        }

    }
}
